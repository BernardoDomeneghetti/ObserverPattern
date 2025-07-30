using System;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Abstractions.Mappers;
using ObserverPattern.Application.Abstractions.Repositories;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Responses;
using ObserverPattern.Domain.Models;

namespace ObserverPattern.Application.Services;

public class StorageAmountUpdateService
    (
        IRepository<ProductStorage> productStorageRepository,
        IMapper<UpdateProductStorageCommand, ProductStorage> mapper
    ) 
    : IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>
{
    public async Task<UpdateStorageProductResponse> ExecuteAsync(UpdateProductStorageCommand command)
    {
        var productStorage = mapper.Map(command);
        await productStorageRepository.AddAsync(productStorage);
        return new UpdateStorageProductResponse("Successfully updated the product storage.");
    }
}
