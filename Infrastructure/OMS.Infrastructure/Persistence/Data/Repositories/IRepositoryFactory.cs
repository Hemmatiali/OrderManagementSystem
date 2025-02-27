namespace OMS.Infrastructure.Persistence.Data.Repositories;

/// <summary>
///     A factory that creates repository instances.
/// </summary>
public interface IRepositoryFactory
{
    /// <summary>
    ///     This method return implementation of the input.
    /// </summary>
    /// <typeparam name="TEntity">the entity which wants to have implementation.</typeparam>
    /// <returns>the implementation of the input entity.</returns>
    IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}
