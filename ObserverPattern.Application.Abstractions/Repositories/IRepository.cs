using System;
using ObserverPattern.Domain.Abstractions;


namespace ObserverPattern.Application.Abstractions.Repositories;

public interface IRepository<in TEntity> where TEntity : class, IEntity
{
    Task AddAsync(TEntity entity);
}
