using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shop.Date.Interfaces;
using Shop.Date.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Date;
using Microsoft.EntityFrameworkCore;
using Shop.Date.Repository;
using Shop.Date.Models;

namespace Shop
{
   
    public class Startup
    {
        private IConfigurationRoot _confSting;
        public Startup(IHostingEnvironment hostEnv)
        {
            _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
            services.AddTransient<IKnifesCategory, CategoryRepository>();
            services.AddTransient<IAllKnives, KnifeRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseDeveloperExceptionPage();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Knive/{action}/{category?}", defaults: new { Controller="Knive", action ="List" });

            });


            AppDBContent content;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObject.Initial(content);
            }

            
        }
    }
}
