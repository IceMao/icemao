using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using icemaoCN.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;


namespace icemaoCN
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var appEnv = services.BuildServiceProvider().GetRequiredService<IApplicationEnvironment>();
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<IceContext>(x => x.UseSqlite("Data source="+appEnv.ApplicationBasePath+"/DataBase/ice.db"));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IceContext>()
                .AddDefaultTokenProviders(); 
            services.AddMvc();
            services.AddSmartUser<User, string>();
        }

        public async void Configure(IApplicationBuilder app,ILoggerFactory logger)
        {
            app.UseStaticFiles();
            logger.MinimumLevel = LogLevel.Information;
            logger.AddConsole();
            logger.AddDebug();
            app.UseIdentity();
            app.UseMvc(x => x.MapRoute("default", "{controller = Home}/{action=Index}/{id?}"));
            await SampleData.InitDB(app.ApplicationServices);
        }

        


        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
