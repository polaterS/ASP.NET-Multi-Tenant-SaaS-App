using MultiTenant.API.Models;
using MultiTenant.API.Services.DTOs;

namespace MultiTenant.API.Services
{
    public interface ITenantService
    {
        Tenant CreateTenant(CreateTenantRequest request);
    }
}
