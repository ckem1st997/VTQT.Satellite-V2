
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.Service.SatelliteService.DataContext;
using VTQT.Satellite.Service.SatelliteService.GenericRepository;
using VTQT.Satellite.Service.SatelliteService.Models;

namespace VTQT.Satellite.Service.SatelliteService.Repository
{
    public class SubscriberServer : ISubscriberServer
    {

        private readonly IGenericRepository<Subscriber> _genericRepository;

        public SubscriberServer(IGenericRepository<Subscriber> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public virtual async Task<int> InsertAsync(Subscriber entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var result = await _genericRepository.InsertAsync(entity);
            return result;
        }

        public virtual async Task<int> UpdateAsync(Subscriber entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var result = await _genericRepository.UpdateAsync(entity);

            return result;
        }

        public virtual async Task<int> DeletesAsync(int id)
        {
            var result = await _genericRepository.DeleteAsync(id);

            return result;
        }


        public virtual async Task<Subscriber> GetByIdAsync(int id)
        {
            //if (!IsNumericType.IsNumeric(id))
            //    throw new ArgumentException(nameof(id));
            return await _genericRepository.GetFirstAsync(id);
        }



        public virtual PageList<Subscriber> GetTable(string q, int s, int l)
        {
            if (string.IsNullOrEmpty(q))
                q = "";
            var result = (from a in _genericRepository.Table
                         where a.CustomerName.Contains(q)
                         select a).Skip(s).Take(l);

            var c = (from a in _genericRepository.Table
                     select a.Id).Count();
            PageList<Subscriber> list= new PageList<Subscriber>();
            list.Count = c;
            list.Data = result;
            return list;
        }

    }
}