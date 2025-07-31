using System;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Responses;
using ObserverPattern.Domain.Abstractions;
using ObserverPattern.Domain.Enums;

namespace ObserverPattern.Application.Services;

public class AvailableProductNotificationService : 
    IApplicationService<AvailableProductNotificationCommand, AvailableProductNotificationResponse>,
    ICustomObserver<UpdateProductStorageCommand>
{
    public async Task<AvailableProductNotificationResponse> ExecuteAsync(AvailableProductNotificationCommand command)
    {
        await Task.Delay(100); // Simulate some async operation
        Console.WriteLine($"The product {command.ProductId} is now available for purchase.");

        return new AvailableProductNotificationResponse($"Notification sent for product: {command.ProductId}");
    }

    public async Task UpdateAsync(UpdateProductStorageCommand command)
    {
        if (command.MovementType == StorageMovementType.In)
        {
            var notificationCommand = new AvailableProductNotificationCommand
            {
                ProductId = command.ProductId
            };
            await ExecuteAsync(notificationCommand);
        }
    }
}