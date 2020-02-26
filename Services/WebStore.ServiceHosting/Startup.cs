using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Interfaces.API;
using WebStore.Clients.Values;
using Microsoft.Extensions.Hosting;
using WebStore.Interfaces.Services;
using WebStore.Services.Implementations;

namespace WebStore.ServiceHosting
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IValuesService, ValuesClient>();
            services.AddScoped<IProductService, SqlProductService>();
            services.AddScoped<IOrdersService, SqlOrdersService>();
            services.AddScoped<ICartService, CookieCartService>();
            services.AddSingleton<IEmployeesService, InMemoryEmployeesService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}