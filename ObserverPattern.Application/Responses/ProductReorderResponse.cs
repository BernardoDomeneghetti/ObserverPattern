using System;
using ObserverPattern.Abstractions.Application.Dtos;

namespace ObserverPattern.Application.Responses;

public class ProductReorderResponse(string message) : IResponse
{
    public string Message { get; set; } = message;
}