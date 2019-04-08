using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            /* *******  REGISTER TYPES *********/
            // By type
            services.AddSingleton<IService, ServiceImplementation1>();

            // Direct instance
            services.AddSingleton(new ServiceImplementation1()); // 

            // Factory method
            services.AddSingleton<ServiceImplementation1>();
            services.AddSingleton<IService>(sp => sp.GetService<ServiceImplementation1>());

            // same for AddTransient a .AddScoped



            /* *******  REGISTER COLLECTIONS *********/
            services.AddTransient<IService, ServiceImplementation1>();
            services.AddTransient<IService, ServiceImplementation2>();
            services.AddTransient<IService, ServiceImplementation3>();


            /* *******  SCRUTOR  *********/
            // https://github.com/khellang/Scrutor

            services.Scan(scan =>
            {
                scan
                    .FromAssemblyOf<Startup>()
                    .AddClasses(c => c.AssignableTo<IService>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
            });

            services.Decorate<IService, ServiceDecorator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();


            // Manual resolve
            var service = app.ApplicationServices.GetService<IService>();

            // Resolve collection
            var services = app.ApplicationServices.GetService<IEnumerable<IService>>();
        }
    }
}
