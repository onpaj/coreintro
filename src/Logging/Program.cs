using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, c) =>
                {
                    c.ClearProviders(); // Clear what CreateDefaultBuilder did

                    //c.AddConfiguration(context.Configuration.GetSection("Logging"));

                    // Microsoft.Extensions.Logging.Console
                    c.AddConsole();
                    // Microsoft.Extensions.Logging.Debug
                    c.AddDebug();

                    // Microsoft.Extensions.Logging.AzureAppServices
                    //c.AddAzureWebAppDiagnostics();

                    // Microsoft.Extensions.Logging.Log4Net.AspNetCore
                    //c.AddLog4Net();

                    // Microsoft.Extensions.Logging.ApplicationInsights
                    c.AddApplicationInsights("InstrumentationKey");
                })
                .UseStartup<Startup>();
    }
}
