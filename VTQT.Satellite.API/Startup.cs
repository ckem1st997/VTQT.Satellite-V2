using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Service.SatelliteService.DataContext;
using VTQT.Satellite.Service.SatelliteService.DIUnitOfWork;
using VTQT.Satellite.Service.SatelliteService.Repository;
using VTQT.Satellite.ShareMVC.Extensions;
using VTQT.Satellite.ShareMVC.Infrastructure.AutoMapper;
using VTQT.Satellite.ShareMVC.Models;

namespace VTQT.Satellite.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDataContext(Configuration);
            services.AddRepository();
            services.AddInfrastructure();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(SubProfile).Assembly);
            services.AddFluentValidation();
            services.AddTransient<IValidator<SubModel>, SubValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            MappingExtensions.Configure(app.ApplicationServices.GetService<IMapper>());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors(x => x
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
