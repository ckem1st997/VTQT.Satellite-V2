
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.Service.SatelliteService.DataContext;

namespace VTQT.Satellite.Service.SatelliteService.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDataConnection _context;
        private ITable<TEntity> _en;
        public GenericRepository(AppDataConnection context)
        {
            _context = context;
        }
        protected virtual ITable<TEntity> _entitie => _en == null ? (_en = _context.GetTable<TEntity>()) : _en;

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0)
        {
            IQueryable<TEntity> query = _context.GetTable<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (records > 0 && orderBy != null)
            {
                query = orderBy(query).Take(records);
            }
            else if (orderBy != null && records == 0)
            {
                query = orderBy(query);
            }
            else if (orderBy == null && records > 0)
            {
                query = query.Take(records);
            }

            return query.ToList();
        }
        //aync

        public async Task<IEnumerable<TEntity>> GetAsync(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0)
        {
            IQueryable<TEntity> query = _context.GetTable<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (records > 0 && orderBy != null)
            {
                query = orderBy(query).Take(records);
            }
            else if (orderBy != null && records == 0)
            {
                query = orderBy(query);
            }
            else if (orderBy == null && records > 0)
            {
                query = query.Take(records);
            }

            return await query.ToListAsync();
        }
        public TEntity GetFirst(object id)
        {
            return _entitie.FirstOrDefault<TEntity>(e => e.Id == (int)id);

        }
        public async Task<TEntity> GetFirstAsync(object id)
        {
            return await _entitie.FirstOrDefaultAsync<TEntity>(e => e.Id == (int)id);
        }


        public int Insert(TEntity entity)
        {
            return _context.Insert(entity);
        }

        public int Delete(object id)
        {
            return _entitie.Where(x => x.Id.Equals((int)id)).Delete();
        }

        public int Update(TEntity entityToUpdate)
        {
            return _context.Update(entityToUpdate);
        }



        public async Task<int> InsertAsync(TEntity entity)
        {
            return await _context.InsertAsync(entity);
        }

        public async Task<int> DeleteAsync(object id)
        {
            return await _entitie.Where(x => x.Id.Equals((int)id)).DeleteAsync();
        }

        public async Task<int> UpdateAsync(TEntity entityToUpdate)
        {
            return await _context.UpdateAsync(entityToUpdate);
        }
        public virtual IQueryable<TEntity> Table => (IQueryable<TEntity>)_entitie;

    }
}

