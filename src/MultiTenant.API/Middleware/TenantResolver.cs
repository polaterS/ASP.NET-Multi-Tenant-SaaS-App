using MultiTenant.API.Services;

namespace MultiTenant.API.Middleware
{
    public class TenantResolver
    {
        private readonly RequestDelegate _requestDelegate;
        public TenantResolver(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
        {
            context.Request.Headers.TryGetValue("tenant", out var tenantFromHeader);
            if(string.IsNullOrEmpty(tenantFromHeader) == false)
            {
                await currentTenantService.SetTenant(tenantFromHeader);
            }
            await _requestDelegate(context);
        }
    }
}
