﻿namespace MultiTenant.API.Services.DTOs
{
    public class CreateTenantRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Isolated { get; set; }
    }
}
