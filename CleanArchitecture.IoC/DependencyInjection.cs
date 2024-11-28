using CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddInfrastructure();

        return services;
    }
}