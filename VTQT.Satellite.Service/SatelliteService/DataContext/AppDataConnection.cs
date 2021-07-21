
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Entity.Entity;

namespace VTQT.Satellite.Service.SatelliteService.DataContext
{
    public class AppDataConnection : DataConnection
    {
        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
            : base(options)
        {
           
        }
        public ITable<Subscriber> Subscribers => GetTable<Subscriber>();

 
    }
}
