using System;
using Microsoft.Extensions.DependencyInjection;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Abstractions.Mappers;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Mappers;
using ObserverPattern.Application.Responses;
using ObserverPattern.Application.Services;
using ObserverPattern.Domain.Abstractions;
using ObserverPattern.Domain.Models;

namespace ObserverPattern.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region Register Application Services
        services.AddSingleton<IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>, StorageAmountUpdateService>();
        services.AddSingleton<IApplicationService<AvailableProductNotificationCommand, AvailableProductNotificationResponse>, AvailableProductNotificationService>();
        services.AddSingleton<IApplicationService<ProductReorderCommand, ProductReorderResponse>, ProductReorderService>();
        services.AddSingleton<IApplicationService<OperationLogCommand, OperationLogResponse>, OperationLoggerService>();
        services.AddSingleton<IMapper<UpdateProductStorageCommand, ProductStorage>, UpdateProductStorageCommandToProductStorageMapper>();
        #endregion
        #region Register Observers
        services.AddKeyedSingleton<ICustomObserver<UpdateProductStorageCommand>, AvailableProductNotificationService>("AvailableProductNotification");
        services.AddKeyedSingleton<ICustomObserver<UpdateProductStorageCommand>, ProductReorderService>("ProductReorder");
        services.AddKeyedSingleton<ICustomObserver<UpdateProductStorageCommand>, OperationLoggerService>("OperationLogger");
        #endregion
        return services;
    }
}
