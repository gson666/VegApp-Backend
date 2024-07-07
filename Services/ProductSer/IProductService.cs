using Backend_almog.DTO;

namespace Backend_almog.Services.ProductSer
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int productId);
        Task<ProductDTO?> CreateProductAsync(ProductDTO productDto);
        Task<ProductDTO?> UpdateProductAsync(ProductDTO productDto);
        Task<bool> DeleteProductAsync(int productId);
    }
}
