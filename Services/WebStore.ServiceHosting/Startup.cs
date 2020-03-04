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
using Microsoft.EntityFrameworkCore;
using WebStore.DAL;
using WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace WebStore.ServiceHosting
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebStoreContext>(x => x
              .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DbInitializer>();
            services.AddControllers();
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<WebStoreContext>();
            services.Configure<IdentityOptions>(
                opt =>
                {
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredUniqueChars = 3;
                    opt.Lockout.AllowedForNewUsers = true;
                    opt.Lockout.MaxFailedAccessAttempts = 10;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    opt.User.RequireUniqueEmail = false;
                });
            services.AddScoped<IValuesService, ValuesClient>();
            services.AddScoped<IProductService, SqlProductService>();
            /*services.AddScoped<IOrdersService, SqlOrdersService>();
            services.AddScoped<ICartService, CookieCartService>();*/
            services.AddSingleton<IEmployeesService, InMemoryEmployeesService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer db)
        {
            db.InitializeAsync().Wait();

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