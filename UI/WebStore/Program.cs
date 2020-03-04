using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebStore.DAL;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            host.Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                /*.ConfigureLogging((hots, log)=> {
                    log.AddFilter("Microsoft", level => level > LogLevel.Information);
                    log.ClearProviders();
                    log.AddConsole(opt => opt.IncludeScopes = true);
                    log.AddDebug();
                })*/
                .UseStartup<Startup>()
                .Build();

    }
}
