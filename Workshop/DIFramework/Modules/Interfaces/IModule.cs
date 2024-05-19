using System;

namespace DIFramework.Modules.Interfaces
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type interfaceType, object attribute);

        object GetInstance(Type classType);

        void SetInstance(Type classType, object instance);
    }
}
