using DIFramework.Attributes;
using DIFramework.Modules.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace DIFramework.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((System.Reflection.BindingFlags)62).Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors().Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("Thre must be only field or only constructor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldsInjection<TClass>();
            }

            return default(TClass);
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type classWanted = typeof(TClass);

            if (classWanted == null)
            {
                return default(TClass);
            }

            ConstructorInfo[] constructors = classWanted.GetConstructors();

            foreach (var constructor in constructors)
            {
                if (CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                Inject inject = (Inject)constructor.GetCustomAttributes(typeof(Inject), true).FirstOrDefault();
                ParameterInfo[] parametersType = constructor.GetParameters();
                object[] constructorParams = new object[parametersType.Length];

                int index = 0;

                foreach (ParameterInfo parameterType in parametersType)
                {
                    Attribute named = parameterType.GetCustomAttribute(typeof(Named), true);
                    Type dependancy = null;

                    if (named == null)
                    {
                        dependancy = this.module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependancy = this.module.GetMapping(parameterType.ParameterType, named);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependancy))
                    {
                        object instance = this.module.GetInstance(dependancy);

                        if (instance != null)
                        {
                            constructorParams[index++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependancy);
                            constructorParams[index++] = instance;
                            this.module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }

                }

                return (TClass)Activator.CreateInstance(classWanted, constructorParams);

            }

            return default(TClass);
        }

        private TClass CreateFieldsInjection<TClass>()
        {
            Type classWanted = typeof(TClass);
            object classWantedInstance = this.module.GetInstance(classWanted);

            if (classWantedInstance == null)
            {
                classWantedInstance = Activator.CreateInstance(classWanted);
                this.module.SetInstance(classWanted, classWantedInstance);
            }

            FieldInfo[] fields = classWanted.GetFields((BindingFlags)62);

            foreach (FieldInfo field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    Inject injection = (Inject)field.GetCustomAttributes(typeof(Inject), true).FirstOrDefault();
                    Type dependancy = null;

                    Attribute named = field.GetCustomAttribute(typeof(Named), true);
                    Type type = field.FieldType;

                    if (named != null)
                    {
                        dependancy = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependancy = this.module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependancy))
                    {
                        object instance = this.module.GetInstance(dependancy);

                        if (instance != null)
                        {
                            instance = Activator.CreateInstance(dependancy);
                            this.module.SetInstance(dependancy, instance);
                        }

                        field.SetValue(classWantedInstance, instance);
                    }
                }
            }

            return (TClass)classWantedInstance;
        }
    }
}
