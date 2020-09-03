using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Vecc.Examples.Vault
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    var builtConfig = configurationBuilder.Build();
                    var keyVaultConfig = builtConfig.GetSection("KeyVault");
                    var vault = keyVaultConfig["vault"];
                    var clientId = keyVaultConfig["clientId"];
                    var clientSecret = keyVaultConfig["secret"];

                    configurationBuilder.AddAzureKeyVault(vault, clientId, clientSecret);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
