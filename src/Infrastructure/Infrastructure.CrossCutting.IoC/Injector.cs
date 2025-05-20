using Domain.RepositoryInterfaces;
using Infrastructure.CrossCutting.Data.Context;
using Infrastructure.CrossCutting.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting.IoC;

public static class Injector
{
    public static IServiceCollection AddIoc(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();

        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}
 