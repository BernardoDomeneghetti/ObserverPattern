using System;
using ObserverPattern.Domain.Abstractions;
using ObserverPattern.Domain.Enums;

namespace ObserverPattern.Domain.Models;

public class ProductStorage: IEntity
{
    public int ProductId { get; set; }
    public StorageMovementType MovementType { get; set; }
    public decimal MovementAmount { get; set; }
    public DateTime MovementDate { get; set; }
    public string Description { get; set; }
}
