using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IRepository<T> where T : class, IEntity
{
    Task<T?> GetByIdAsync(long id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}