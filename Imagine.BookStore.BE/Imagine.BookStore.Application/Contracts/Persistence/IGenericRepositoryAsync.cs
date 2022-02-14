namespace Imagine.BookStore.Application.Contracts.Persistence;
public interface IGenericRepositoryAsync<T> where T : class
{
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
}
