
using Microsoft.EntityFrameworkCore;
using MultiTenant.API.Extensions;
using MultiTenant.API.Middleware;
using MultiTenant.API.Models;
using MultiTenant.API.Services;

namespace MultiTenant.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICurrentTenantService, CurrentTenantService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<TenantDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAndMigrateTenantDatabases(builder.Configuration);

            builder.Services.AddTransient<ITenantService, TenantService>();
            builder.Services.AddTransient<IProductService, ProductService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<TenantResolver>();
            app.MapControllers();

            app.Run();
        }
    }
}
