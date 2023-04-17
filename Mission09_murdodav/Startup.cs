using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission09_murdodav.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// added for the assignment
using Mission09_murdodav.Models;
using Microsoft.AspNetCore.Http;


namespace Mission09_murdodav
{
    public class Startup
    {
        // (this gets its Configuration from the Configuration in the constructor)
        // I moved this up to better match what Hilton did.
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config_temp)
        {
            Configuration = config_temp;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // added for the assignment
            // connecting the DbContext object to the Connection string to connect to the actual database
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            // added for the assignment
            // each Http request will get its own repository object to connect to the database with
            services.AddScoped<IBookStoreRepository, EFBookStoreRepository>();

            // allowing Razor pages
            services.AddRazorPages();

            // adding both of the below to make Session storage work :)
            services.AddDistributedMemoryCache();
            services.AddSession();

            // Added for Mission 11
            services.AddScoped<Cart>(x => SessionCart.GetCart(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IBookPurchaseRepository, EFBookPurchaseRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles(); // go to wwwroot first to look for pages

            app.UseSession(); // allowing our app to use Session

            app.UseRouting(); // allowing our app to use endpoints, I believe

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                // If we are passed a Book Cateogry and a page number
                endpoints.MapControllerRoute("CategoryPage", "{bookCategory}/page-{pageNum}", new { Controller = "Home", action = "Index" });

                // If we are passed only a page number
                endpoints.MapControllerRoute(
                    "Page", // name
                    "page-{pageNum}", // pattern
                    new { Controller = "Home", action = "Index", pageNum = 1 }); // defaults

                // If we are passed only a category
                endpoints.MapControllerRoute(
                    name: "Category",
                    pattern: "{bookCategory}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                    );

                // If we are passed nothing :)
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

        }
    }
}
