using Finaktiva.Infrastructur.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finaktiva.Infrastructur.DataAccess.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly EntityDbContext _dataContext;

        private readonly DbSet<TEntity> _entities;
        public RepositoryBase(EntityDbContext dataContext)
        {
            _dataContext = dataContext;
            _entities = dataContext.Set<TEntity>();
        }
        public bool Add(TEntity entity)
        {
            _entities.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Delete(object id)
        {
            TEntity entityDelete = _entities.Find(id);
            if (entityDelete != null)
            {
                _entities.Remove(entityDelete);
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }

        public async Task<IQueryable<TEntity>> GetAll() => _entities.AsQueryable();

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await GetAll();
            query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            return query.FirstOrDefault(where);
        }
    }
}
