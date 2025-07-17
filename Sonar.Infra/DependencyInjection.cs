using System;
using Microsoft.Extensions.DependencyInjection;
using Sonar.Application.Interfaces.Repositories;
using Sonar.Infra.Repositories;

namespace Sonar.Infra;

public static class DependencyInjection
{

    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
