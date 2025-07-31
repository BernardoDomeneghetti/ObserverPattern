using System.Windows.Input;
using ObserverPattern.Application.Abstractions.Dtos;

namespace ObserverPattern.Application.Commands;

public record class AvailableProductNotificationCommand : IRequest
{
    public int ProductId { get; set; }
}
