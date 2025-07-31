using ObserverPattern.Application.Abstractions.Dtos;
using ObserverPattern.Domain.Enums;

namespace ObserverPattern.Application.Commands;

public record class UpdateProductStorageCommand: IRequest
{
    public int ProductId { get; set; }
    public decimal MovementAmount { get; set; }
    public StorageMovementType MovementType { get; set; }
    public string MovementDescription { get; set; }
}
