using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Set<TEntity>().ToListAsync(cancellationToken: cancellationToken);

    /// <inheritdoc />
    public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(
        Expression<Func<TEntity, bool>>? predicate,
        Expression<Func<TEntity, TResult>>? selectColumns = null,
        Expression<Func<TEntity, object>>[]? includeProperties = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int? skip = null,
        int? take = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        // Include related properties if provided
        if (includeProperties != null)
        {
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        // Apply predicate if provided
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        // Apply ordering if provided
        if (orderBy != null)
        {
            query = orderBy(query);
        }

        // Apply pagination (skip and take) if provided
        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        // If selectColumns is null, return the entire entity as TResult
        if (selectColumns != null)
        {
            return await query.Select(selectColumns).ToListAsync(cancellationToken);
        }

        // If no selectColumns, cast the query to TResult (which must be TEntity in this case)
        return await query.Cast<TResult>().ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Set<TEntity>().FindAsync(id, cancellationToken);

    /// <inheritdoc/>
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    #endregion

}