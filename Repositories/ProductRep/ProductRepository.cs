using Backend_almog.Data;
using Backend_almog.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_almog.Repositories.ProductRep
{
    public class ProductRepository : IProductRepository
    {
        private readonly Dal _context;

        public ProductRepository(Dal context)
        {
            _context = context;
        }

        public async Task<Product?> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var ProductToDelete = await _context.Products.FindAsync(productId);
            if (ProductToDelete == null) return false;

            _context.Products.Remove(ProductToDelete);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;

        }
    }
}
