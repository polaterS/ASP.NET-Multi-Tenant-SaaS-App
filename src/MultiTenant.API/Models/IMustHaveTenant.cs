﻿namespace MultiTenant.API.Models
{
    public interface IMustHaveTenant
    {
        public string TenantId { get; set; }
    }
}
