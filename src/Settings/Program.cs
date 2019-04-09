using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ori.Configuration.Shared.Enums;
using Ori.Configuration.Urls.Provider.Core.Extensions;

namespace Settings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, c) =>
                {
                    c.Sources.Clear(); // Clear all from CreateDefaultBuilder

                    // Microsoft.Extensions.Configuration.Json / Xml / Ini / FileExtension
                    c.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    c.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        // dotnet user-secrets set "SettingsClass:SecretPhrase" "bubak"--project D:\Work\Oriflame\ArchSync\coreintro\src\Settings
                        // dotnet user-secrets remove "SettingsClass:SecretPhrase" --project D:\Work\Oriflame\ArchSync\coreintro\src\Settings


                        // Microsoft.Extensions.Configuration.UserSecrets
                        c.AddUserSecrets<Startup>();

                        // Microsoft.Extensions.Configuration.KeyVault
                        //c.AddKeyVault();
                    }

                    // Ori.Configuration.Urls.Provider.Core
                    c.AddUrlConfigurationForTenants(EnvironmentType.UAT, reloadOnChange: true);

                    // Microsoft.Extensions.Configuration.EnvironmentVariables
                    c.AddEnvironmentVariables();

                    // Microsoft.Extensions.Configuration.CommandLine
                    c.AddCommandLine(args);
                })
                .UseStartup<Startup>();
    }
}
