using API.Modules;
using Asp.Versioning.Builder;
using Asp.Versioning;

namespace API.Extensions;

internal static class WebApplicationBuilderExtensions
{
    internal static void MapEndpoints(this WebApplication app)
    {
        IEnumerable<IModule> modules = typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();

        foreach (IModule module in modules)
        {
            // General common configuration for endpoints here
            ApiVersionSet apiVersionSet = app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1))
                .ReportApiVersions()
                .Build();

            RouteGroupBuilder group = app
                .MapGroup("api/v{version:apiVersion}")
                .CacheOutput()
                .WithTags("User")
                .WithApiVersionSet(apiVersionSet)
                .RequireRateLimiting("fixed");

            module.MapEndpoints(group);
        }
    }
}