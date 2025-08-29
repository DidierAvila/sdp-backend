using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SDP.Domain.Common;
using SDP.Domain.Repository;
using SDP.Infrastructure.DbContexts;

namespace SDP.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal readonly SdpContex _context;
        public RepositoryBase(SdpContex context) => _context = context;

        internal DbSet<TEntity> EntitySet => _context.Set<TEntity>();

        public async Task<TEntity?> Delete(int id, CancellationToken cancellationToken)
        {
            TEntity? entity = await EntitySet.FindAsync(id, cancellationToken);
            if (entity != null)
            {
                EntitySet.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return entity;
        }

        public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> expr, CancellationToken cancellationToken)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>?> Finds(Expression<Func<TEntity, bool>> expr, CancellationToken cancellationToken)
        {
            return await EntitySet.AsNoTracking().Where(expr).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByID(int id, CancellationToken cancellationToken)
        {
            return await EntitySet.FindAsync(id, cancellationToken);
        }

        public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
        {
            var result = await EntitySet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }

        public async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<(IEnumerable<TEntity> items, int totalCount)> GetPagedAsync(
            Expression<Func<TEntity, bool>>? filterExpression,
            int pageNumber,
            int pageSize,
            string? orderBy,
            CancellationToken cancellationToken)
        {
            var query = EntitySet.AsNoTracking();
            
            if (filterExpression != null)
                query = query.Where(filterExpression);
            
            var totalCount = await query.CountAsync(cancellationToken);
            
            if (!string.IsNullOrWhiteSpace(orderBy))
                query = query.ApplySort(orderBy);
            
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
            
            return (items, totalCount);
        }
    }
}
