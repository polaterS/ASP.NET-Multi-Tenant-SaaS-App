using MultiTenant.API.Models;
using MultiTenant.API.Services.DTOs;

namespace MultiTenant.API.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product CreateProduct(CreateProductRequest request);
        bool DeleteProduct(int id);
    }
}
