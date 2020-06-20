using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiniAppHakaton.Helpers;

namespace MiniAppHakaton
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //StravaTrackDeserializeHelper strava = new StravaTrackDeserializeHelper();
           // strava.XMLToListOfPoints("C:\\Users\\Nikita\\Downloads\\Telegram Desktop\\strava_Space Invader.gpx");
            var host = CreateHostBuilder(args).Build();

            var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;

            var bootstrap = services.GetRequiredService<Bootstrap.Bootstrap>();
            await bootstrap.Run();

            await host.RunAsync();

            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
