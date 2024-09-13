using Application.Contracts.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IRepository<>), typeof(JsonRepository<>)); // Add Singleton for concurrency file access

        return services;
    }
}
