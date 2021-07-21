
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Service.SatelliteService.GenericRepository;

namespace VTQT.Satellite.Service.SatelliteService.DIUnitOfWork
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }
    }
}
