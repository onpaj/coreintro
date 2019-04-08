using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            // https://github.com/aspnet/AspNetCore/blob/4e44025a52e4b73aa17e09a8041b0e166e0c5ce0/src/DefaultBuilder/src/WebHost.cs
            return WebHost
                .CreateDefaultBuilder(args)
                
                //.ConfigureLogging(conf =>
                //{
                //    conf
                //        .AddConsole()
                //        .AddDebug()
                //        .AddEventSourceLogger();
                //})
                
                //.ConfigureAppConfiguration(conf => 
                //{
                //    conf
                //        .AddJsonFile("MyConfigFile.json", true)
                //        .AddXmlFile("MyAnotherConfigFile.xml", optional: true);
                //})

                .UseStartup<Startup>();
        }
    }
}
