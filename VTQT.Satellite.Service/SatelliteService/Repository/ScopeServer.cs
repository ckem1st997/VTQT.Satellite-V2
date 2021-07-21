using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTQT.Satellite.Service.SatelliteService.Repository
{
    public static class ServiceRepository
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ISubscriberServer, SubscriberServer>();

        }
    }
}
