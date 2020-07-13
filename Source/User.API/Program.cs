using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace User.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                   .ConfigureNLog("nlog.config")
                   .GetCurrentClassLogger();

            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<UserContext>();

                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "An error occurred while migrating the database.");
                }
            }
            // run the web app
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
             .UseNLog();
    }
}
