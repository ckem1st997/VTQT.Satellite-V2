using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTQT.Satellite.Service.SatelliteService.DataContext
{
    public static class ServiceDataContext
    {
        private static readonly string Connectionstring = "DefaultConnection";

        public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLinqToDbContext<AppDataConnection>((provider, options) => {
                options
                .UseMySql(configuration.GetConnectionString(Connectionstring))
                .UseDefaultLogging(provider);
            });
        }
    }
}