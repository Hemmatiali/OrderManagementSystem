namespace OMS.Infrastructure.Persistence.Data.Repositories;

/// <inheritdoc cref="IRepositoryFactory"/>
public sealed class RepositoryFactory : IRepositoryFactory
{
    #region Fields

    private readonly OMSDbContext _context;

    #endregion

    #region Ctor

    public RepositoryFactory(OMSDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        return new BaseRepository<TEntity>(_context);
    }

    #endregion
}