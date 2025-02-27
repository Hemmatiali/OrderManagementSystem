using Microsoft.EntityFrameworkCore;

namespace OMS.Infrastructure.Persistence.Data.Repositories;

/// <inheritdoc cref="IBaseRepository"/>
public sealed class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    #region Fields

    private readonly OMSDbContext _context;

    #endregion

    #region Ctor

    public BaseRepository(OMSDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Set<TEntity>().ToListAsync(cancellationToken: cancellationToken);

    #endregion

}