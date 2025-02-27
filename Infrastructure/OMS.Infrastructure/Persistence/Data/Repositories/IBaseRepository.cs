namespace OMS.Infrastructure.Persistence.Data.Repositories;

/// <summary>
///     Generic repository providing basic CRUD operations.
/// </summary>
/// <typeparam name="TEntity">The type of entity managed by the repository.</typeparam>
public interface IBaseRepository<TEntity> where TEntity : class
{
    /// <summary>
    ///     Asynchronously retrieves all entities from the repository.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation, yielding an Enumerable of <typeparamref name="TEntity"/>.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}
