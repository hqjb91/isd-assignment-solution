namespace API.Modules;

public interface IModule
{
    public IServiceCollection RegisterModules(IServiceCollection services);
    public RouteGroupBuilder MapEndpoints(RouteGroupBuilder group);
}