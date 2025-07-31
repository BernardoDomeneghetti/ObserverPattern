using Microsoft.Extensions.DependencyInjection;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Abstractions.Mappers;
using ObserverPattern.Application.Abstractions.Repositories;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Responses;
using ObserverPattern.Domain.Abstractions;
using ObserverPattern.Domain.Models;

namespace ObserverPattern.Application.Services;

public class StorageAmountUpdateService
    (
        [FromKeyedServices("AvailableProductNotification")]ICustomObserver<UpdateProductStorageCommand> availableProductNotificationObserver,
        [FromKeyedServices("ProductReorder")]ICustomObserver<UpdateProductStorageCommand> productReorderObserver,
        [FromKeyedServices("OperationLogger")]ICustomObserver<UpdateProductStorageCommand> operationLoggerObserver,
        IRepository<ProductStorage> productStorageRepository,
        IMapper<UpdateProductStorageCommand, ProductStorage> mapper
    ) 
    : IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>,
    ICustomObservable<UpdateProductStorageCommand>
{
    public List<ICustomObserver<UpdateProductStorageCommand>> Observers { get; set; }
    public async Task<UpdateStorageProductResponse> ExecuteAsync(UpdateProductStorageCommand command)
    {
        var productStorage = mapper.Map(command);
        await productStorageRepository.AddAsync(productStorage);
        RegisterObservers(availableProductNotificationObserver, productReorderObserver, operationLoggerObserver);
        await UpdateObservers(command);
        return new UpdateStorageProductResponse("Successfully updated the product storage.");
    }

    public void RegisterObservers(params ICustomObserver<UpdateProductStorageCommand>[] observers)
    {
        Observers = [.. observers];
    }

    public async Task UpdateObservers(UpdateProductStorageCommand command)
    {
        foreach (var observer in Observers)
        {
            await observer.UpdateAsync(command);
        }
    }

}
