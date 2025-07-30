using ObserverPattern.Abstractions.Application.Dtos;

namespace ObserverPattern.Application.Responses;

public record class UpdateStorageProductResponse: IResponse
{
    public UpdateStorageProductResponse(string message)
    {
        Message = message;
    }

    public string Message { get; set; } = string.Empty;
}
