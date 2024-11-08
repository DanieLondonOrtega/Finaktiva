using System.Linq.Expressions;

namespace Finaktiva.Infrastructur.DataAccess.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        bool Add(TEntity entity);
        bool Delete(object id);
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
