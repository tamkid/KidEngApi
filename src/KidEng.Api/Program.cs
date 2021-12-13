using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KidEng.Api.Extensions;
using KidEng.Infrastructure.Persistence;

namespace KidEng.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.MigrationDatabase<KidEngContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<KidEngContextSeed>>();
                KidEngContextSeed.SeedAsync(context, logger).Wait();
            });

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
