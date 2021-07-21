
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.Service.SatelliteService.GenericRepository;
using VTQT.Satellite.Service.SatelliteService.Models;

namespace VTQT.Satellite.Service.SatelliteService.Repository
{
    public interface ISubscriberServer
    {
        Task<int> InsertAsync(Subscriber entity);

        Task<int> UpdateAsync(Subscriber entity);

        Task<int> DeletesAsync(int id);


        Task<Subscriber> GetByIdAsync(int id);
        PageList<Subscriber> GetTable(string q, int s, int l);

    }
}

