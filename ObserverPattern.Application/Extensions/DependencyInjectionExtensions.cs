using System;
using Microsoft.Extensions.DependencyInjection;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Abstractions.Mappers;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Mappers;
using ObserverPattern.Application.Responses;
using ObserverPattern.Application.Services;
using ObserverPattern.Domain.Models;

namespace ObserverPattern.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>, StorageAmountUpdateService>();
        services.AddScoped<IMapper<UpdateProductStorageCommand, ProductStorage>, UpdateProductStorageCommandToProductStorageMapper>();

        return services;
    }
}
