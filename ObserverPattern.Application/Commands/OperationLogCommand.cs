using ObserverPattern.Application.Abstractions.Dtos;

namespace ObserverPattern.Application.Commands;

public record class OperationLogCommand : IRequest
{
    public string LogMessage { get; set; }
}
