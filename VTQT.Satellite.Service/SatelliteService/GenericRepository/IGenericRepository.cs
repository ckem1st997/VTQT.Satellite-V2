using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VTQT.Satellite.Entity.Entity;

namespace VTQT.Satellite.Service.SatelliteService.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0);


        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0);

        TEntity GetFirst(object id);
        Task<TEntity> GetFirstAsync(object id);


        int Insert(TEntity entity);

        int Delete(object id);

        int Update(TEntity entity);

        Task<int> InsertAsync(TEntity entity);

        Task<int> DeleteAsync(object id);

        Task<int> UpdateAsync(TEntity entity);

        IQueryable<TEntity> Table { get; }
    }
}
