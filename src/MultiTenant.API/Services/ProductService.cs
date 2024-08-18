using MultiTenant.API.Models;
using MultiTenant.API.Services.DTOs;

namespace MultiTenant.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public Product CreateProduct(CreateProductRequest request)
        {
            var product = new Product();
            product.Name = request.Name;

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Where(x => x.Id == id).FirstOrDefault();

            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
