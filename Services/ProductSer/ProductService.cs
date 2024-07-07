using AutoMapper;
using Backend_almog.DTO;
using Backend_almog.Models;
using Backend_almog.Repositories.ProductRep;

namespace Backend_almog.Services.ProductSer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO?> CreateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var newProduct =await _productRepository.CreateProductAsync(product);
            return _mapper.Map<ProductDTO>(newProduct);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            return await _productRepository.DeleteProductAsync(productId);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int productId)
        {
           var product = await _productRepository.GetProductByIdAsync(productId);
           return _mapper.Map<ProductDTO?>(product);
        }

        public async Task<ProductDTO?> UpdateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var updatedProduct = await _productRepository.UpdateProductAsync(product);
            return _mapper.Map<ProductDTO>(updatedProduct);
        }
    }
}
