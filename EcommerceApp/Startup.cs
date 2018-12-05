using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EcommerceApp.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using EcommerceApp.Services.Infrastructure;
using EcommerceApp.Services.Repository;

namespace EcommerceApp
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
           
            services.AddDbContext<DataContext.AppContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<Customer, ApplicationRole>()
               .AddEntityFrameworkStores<DataContext.AppContext>()
               .AddDefaultTokenProviders();

            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<ISubCategory, SubCategoryRepository>();
            services.AddScoped<IOrder, OrderRepository>();
            services.AddScoped<IOrderLine, OrderLineRepository>();
            services.AddScoped<IPicture, PictureRepository>();
            services.AddScoped<ICartItem, CartItemRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSpaStaticFiles();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
                //Admin Area route
                routes.MapRoute(
                    name: "AdminAreaProduct",
                    template: "{area:exists}/{controller=Products}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "AdminAreaCategory",
                    template: "{area:exists}/{controller=Products}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
