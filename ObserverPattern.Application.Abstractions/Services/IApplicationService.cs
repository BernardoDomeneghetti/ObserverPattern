using System;
using System.Windows.Input;
using ObserverPattern.Abstractions.Application.Dtos;
using ObserverPattern.Application.Abstractions.Dtos;

namespace ObserverPattern.Abstractions.Application.Services;

public interface IApplicationService<TCommand, TResponse>
    where TCommand : IRequest
    where TResponse : IResponse
{
    Task<TResponse> ExecuteAsync(TCommand command);
}
