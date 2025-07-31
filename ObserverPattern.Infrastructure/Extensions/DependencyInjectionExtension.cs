using System;
using Microsoft.Extensions.DependencyInjection;
using ObserverPattern.Application.Abstractions.Repositories;
using ObserverPattern.Domain.Models;
using ObserverPattern.Infrastructure.Repositories;

namespace ObserverPattern.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<ProductStorage>, ProductStorageRepository>();
        return services;
    }
}
