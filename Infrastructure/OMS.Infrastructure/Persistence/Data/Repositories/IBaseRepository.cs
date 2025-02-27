using System.Linq.Expressions;

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

    /// <summary>
    ///     Asynchronously retrieves all entities from the repository.
    /// </summary>
    /// <param name="predicate">The condition to filter the entities.</param>
    /// <param name="includeProperties">The properties to include in the query.</param>
    /// <param name="selectColumns">The columns to select in the query. If null, selects the entire entity.</param>
    /// <param name="orderBy">The expression to order the results by.</param>
    /// <param name="skip">The number of items to skip.</param>
    /// <param name="take">The number of items to take.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. Defaults to CancellationToken.None.</param>
    /// <returns>A task representing the asynchronous operation, yielding an Enumerable of <typeparamref name="TEntity"/>.</returns>
    Task<IEnumerable<TResult>> GetAllAsync<TResult>(
        Expression<Func<TEntity, bool>>? predicate,
        Expression<Func<TEntity, TResult>>? selectColumns = null,
        Expression<Func<TEntity, object>>[]? includeProperties = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int? skip = null,
        int? take = null,
        CancellationToken cancellationToken = default);
}
