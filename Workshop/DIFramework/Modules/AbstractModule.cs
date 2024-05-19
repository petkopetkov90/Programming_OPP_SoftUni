using DIFramework.Attributes;
using DIFramework.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            implementations = new Dictionary<Type, Dictionary<string, Type>>();
            instances = new Dictionary<Type, object>();
        }

        protected void CreateMapping<TInterfaceType, TClassType>()
        {
            if (!implementations.ContainsKey(typeof(TInterfaceType)))
            {
                implementations.Add(typeof(TInterfaceType), new Dictionary<string, Type>());
            }

            implementations[typeof(TInterfaceType)].Add(typeof(TClassType).Name, typeof(TClassType));
        }

        public Type GetMapping(Type interfaceType, object attribute)
        {
            Dictionary<string, Type> currentImplementation = this.implementations[interfaceType];

            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {interfaceType.FullName}");
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;

                string dependancyName = named.Name;
                type = currentImplementation[dependancyName];
            }

            return type;
        }

        public void SetInstance(Type classType, object instance)
        {
            if (!this.instances.ContainsKey(classType))
            {
                this.instances.Add(classType, instance);
            }
        }

        public object GetInstance(Type classType)
        {
            this.instances.TryGetValue(classType, out object instance);

            return instance;
        }

        public abstract void Configure();
    }
}
