using Entity.Data;
using Entity.Data.Interface;
using Entity.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RockFood.Api.Filter;
using RockFood.Interfaces;
using RockFood.Models;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DataContext, DataContext>();
            services.AddSingleton<IFoodable, Food>();
            services.AddSingleton<IMemoryCacheable<IFoodable>, MemoryCache<IFoodable> >();
            services.AddSingleton<IExchangerable, CurrencyExchanger>();
            services.AddSingleton<IFoodOperation, FoodOperation>();
            services.AddSingleton<ILogger<MyExceptionFilter>, Logger<MyExceptionFilter>>();
            services.AddSingleton<ILogger<BuyFoodActionFilter>, Logger<BuyFoodActionFilter>>();

            services.AddControllers();
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RockFood.Api", Version = "v1" });
            });
            services.AddControllers(options=>
            {
                options.Filters.Add(typeof(MyExceptionFilter));
            });

            services.AddScoped<BuyFoodActionFilter>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RockFood.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "mvcFood",
                    pattern: "mvc/food/{action=Index}/{id?}",
                    defaults: new { controller = "FoodMVC"});

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=FoodMVC}/{action=Index}/{id?}");
            });
        }
    }
}
