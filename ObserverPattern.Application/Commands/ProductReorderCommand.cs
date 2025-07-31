using System;
using ObserverPattern.Application.Abstractions.Dtos;

namespace ObserverPattern.Application.Commands;

public class ProductReorderCommand : IRequest
{
    public int ProductId { get; set; }
    public decimal Amount { get; set; }
}
