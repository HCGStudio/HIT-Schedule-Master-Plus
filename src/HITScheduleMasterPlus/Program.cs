using System.Threading.Tasks;
using ElectronNET.API;
using HITScheduleMasterPlus.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HITScheduleMasterPlus
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Settings.Load();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseElectron(args);
                });
        }
    }
}