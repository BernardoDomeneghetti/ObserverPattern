using System;
using System.Windows.Input;

namespace ObserverPattern.Domain.Abstractions;

public interface ICustomObserver<in TCommand> where TCommand : class
{
    Task UpdateAsync(TCommand command);
}
