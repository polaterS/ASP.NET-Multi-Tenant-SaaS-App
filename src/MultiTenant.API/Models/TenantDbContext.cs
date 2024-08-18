using Microsoft.EntityFrameworkCore;

namespace MultiTenant.API.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> opt) : base(opt)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
