using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTQT.Satellite.Service.SatelliteService.Models
{
    public class PageList<TEntity>
    {
        public int Count { get; set; }
        public IQueryable<TEntity> Data { get; set; }
    }
}
