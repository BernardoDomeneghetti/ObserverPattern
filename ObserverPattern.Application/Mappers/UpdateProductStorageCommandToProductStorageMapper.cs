using System;
using ObserverPattern.Application.Abstractions.Mappers;
using ObserverPattern.Application.Commands;
using ObserverPattern.Domain.Models;

namespace ObserverPattern.Application.Mappers;

public class UpdateProductStorageCommandToProductStorageMapper:IMapper<UpdateProductStorageCommand, ProductStorage>
{
    public ProductStorage Map(UpdateProductStorageCommand source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return new ProductStorage
        {
            ProductId = source.ProductId,
            MovementAmount = source.MovementAmount,
            MovementType = source.MovementType,
            Description = source.MovementDescription
        };
    }
}
