using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;
using Microsoft.AspNetCore.Identity;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:RecipeAddWebsite:ConnectionString"]));

            services.AddTransient<IRepository, EFRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();
            services.AddMvc();


       services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:RecipesIdentity:ConnectionString"]));
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

        }

      

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
           app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "",
                    template: "{controller}/{action}");
                routes.MapRoute(
                   name: "",
                   template: "{controller=Home}/{action=DataPage}");
            });


            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
