
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EMS.DLL
{
    /// <summary>
    /// https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmsDbContext>
    {
        public EmsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../EMS.Web/appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<EmsDbContext>();
            var connectionString = configuration.GetConnectionString("EmployeeDbConnection");
            builder.UseSqlServer(connectionString);
            return new EmsDbContext(builder.Options);
        }
    }
}
