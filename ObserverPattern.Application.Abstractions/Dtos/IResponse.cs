using System;

namespace ObserverPattern.Abstractions.Application.Dtos;

public interface IResponse
{
    public string Message { get; set; }
}
