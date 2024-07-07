using Backend_almog.Models;

namespace Backend_almog.Repositories.ProductRep
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int productId);
        Task<Product?> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int productId);
    }
}
