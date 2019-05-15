using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ni.Infrastructure;

namespace Ni
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDB();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void CreateDB()
        {
            using (var context = new AppDbContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();
            }
        }
    }
}
