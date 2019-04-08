using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostingConsole
{
    class Program
    {
        static Task Main(string[] args)
        {
            // Microsoft.Extensions.Hosting
            var builder = new HostBuilder();

            builder
                .ConfigureLogging(c =>
                {
                    c
                        .AddDebug()
                        .AddConsole();
                })
                .ConfigureAppConfiguration((context, conf) =>
                {
                    conf
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true,
                            reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    //services.AddSingleton()
                    services.AddHostedService<AppService>();
                });


            return builder.Build().RunAsync();
        }
    }
}
