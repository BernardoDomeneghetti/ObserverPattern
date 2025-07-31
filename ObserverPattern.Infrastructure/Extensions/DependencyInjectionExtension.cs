using System;
using Microsoft.Extensions.DependencyInjection;
using ObserverParttern.Infrastructure.Repositories;
using ObserverPattern.Application.Abstractions.Repositories;
using ObserverPattern.Domain.Models;

namespace ObserverPattern.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<ProductStorage>, ProductStorageRepository>();
        return services;
    }
}
