using EMS.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;


namespace EMS.DLL
{
    /// <summary>
    /// https://www.learnentityframeworkcore.com/migrations/seeding
    /// 
    /// https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
    /// </summary>
    public class EmsDbContext : IdentityDbContext<ApplicationUser>
    {
        public EmsDbContext(DbContextOptions<EmsDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
