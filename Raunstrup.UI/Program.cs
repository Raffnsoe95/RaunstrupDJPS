using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Raunstrup.UI.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace Raunstrup.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var host =CreateHostBuilder(args).Build();

            SeedAsync(host).GetAwaiter().GetResult();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
                    webBuilder.UseStartup<Startup>();
        });

        public static async Task SeedAsync(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<UserManagementContext>();
                    context.Database.Migrate();

                    var configuration = services.GetRequiredService<IConfiguration>();
                    await UserManagementDbInitializer.InitializeAsync(services, configuration).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
        }
    }
}
