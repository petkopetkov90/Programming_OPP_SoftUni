using DIFramework.Injectors;
using DIFramework.Modules.Interfaces;

namespace DIFramework
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
