using System;

namespace ObserverPattern.Domain.Abstractions;

public interface ICustomObservable<TCommand> where TCommand : class
{
    protected List<ICustomObserver<TCommand>> Observers { get; set; }
    void RegisterObservers(params ICustomObserver<TCommand>[] observers);
    protected Task UpdateObservers(TCommand command);
}
