using API.Modules;

namespace API.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddModules(this IServiceCollection services)
    {
        IEnumerable<IModule> modules = typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();

        foreach (IModule module in modules)
        {
            module.RegisterModules(services);
        }
    }
}