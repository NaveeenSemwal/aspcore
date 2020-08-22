using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.BLL.Abstract;
using EMS.BLL.Implement;
using EMS.DLL;
using EMS.DLL.Abstract;
using EMS.DLL.Implementation;
using EMS.Entity;
using EMS.Web.SignalRHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace EMS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
          options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllersWithViews(config =>
            {
                // Applying Global filter
                var policy = new AuthorizationPolicyBuilder()
                         .RequireAuthenticatedUser()
                         .Build();

                config.Filters.Add(new AuthorizeFilter(policy));

            });

            services.AddTransient<IEmployeeService, EmployeeService>();
            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<EmsDbContext>();

            services.AddSignalR();

            services.AddDbContextPool<EmsDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EmployeeDbConnection")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Global exception handling in asp net core mvc
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePagesWithRedirects("/Error/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<EmployeeHub>("/EmployeeHub");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
