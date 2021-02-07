using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartMedDB.Data;

namespace SmartMedDB
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
            services.AddDbContext<SmartMedDBContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("MedicationsDBConnection")));

            services.AddControllers();

            // used for Automapper DependencyInjection package
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // dependency injection for the mock database
            // services.AddScoped<ISmartMedDBRepo, MockSmartMedDBRepo>();

            // dependency injection for the real database
            services.AddScoped<ISmartMedDBRepo, SmartMedDBRepo>();
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
