using ObserverPattern.Abstractions.Application.Dtos;

namespace ObserverPattern.Application.Responses;

public record class AvailableProductNotificationResponse : IResponse
{
    public string Message { get; set; }

    public AvailableProductNotificationResponse(string message) => Message = message;
}
