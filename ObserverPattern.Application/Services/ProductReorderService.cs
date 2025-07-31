using System;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Responses;
using ObserverPattern.Domain.Abstractions;
using ObserverPattern.Domain.Enums;
using ObserverPattern.Domain.Models;

namespace ObserverPattern.Application.Services;

public class ProductReorderService : 
    IApplicationService<ProductReorderCommand, ProductReorderResponse>,
    ICustomObserver<UpdateProductStorageCommand>
{
    public Task<ProductReorderResponse> ExecuteAsync(ProductReorderCommand command)
    {
        // Simulate some async operation
        return Task.Run(() =>
        {
            Console.WriteLine($"Reordering product with ID: {command.ProductId}, Amount: {command.Amount}");
            return new ProductReorderResponse($"Product with ID: {command.ProductId} reordered successfully.");
        });
    }

    public async Task UpdateAsync(UpdateProductStorageCommand command)
    {
        if (command.MovementType == StorageMovementType.Out)
        {
            var productReorderCommand = new ProductReorderCommand
            {
                ProductId = command.ProductId,
                Amount = command.MovementAmount
            };
            
            await ExecuteAsync(productReorderCommand);
        }
    }
}
