using System.Linq.Expressions;
using SDP.Domain.Common;

namespace SDP.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);
        Task<(IEnumerable<TEntity> items, int totalCount)> GetPagedAsync(
            Expression<Func<TEntity, bool>>? filterExpression,
            int pageNumber, 
            int pageSize, 
            string? orderBy, 
            CancellationToken cancellationToken);
        Task<TEntity?> GetByID(int id, CancellationToken cancellationToken);
        Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> CreateMany(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task<TEntity?> Delete(int id, CancellationToken cancellationToken);
        Task Update(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> Find(Expression<Func<TEntity, bool>> expr, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>?> Finds(Expression<Func<TEntity, bool>> expr, CancellationToken cancellationToken);
    }
}
