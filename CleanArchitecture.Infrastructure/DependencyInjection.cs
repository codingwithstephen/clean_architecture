using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Common.Persistence;
using CleanArchitecture.Infrastructure.Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<CleanArchitectureDbContext>(options =>
        {
            options.UseSqlite("Data Source=CleanArchitecture.db");
        });
        
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<CleanArchitectureDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}