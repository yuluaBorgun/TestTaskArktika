using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantsAPI.DataFasades;
using RestaurantsAPI.Migrations;
using RestaurantsAPI.Models;

namespace RestaurantsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = new RestaurantConfiguration(configuration);
        }
        public RestaurantConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ICRUDdbOperations<Restaurant>, RestaurantFasad>();
            services.AddTransient<ICRUDdbOperations<Kitchen>, KitchenFasad>();
            services.AddDbContext<DataBaseContext>(opt => {
                opt.UseSqlite(Configuration.DBConnectionString);
            });                    
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
