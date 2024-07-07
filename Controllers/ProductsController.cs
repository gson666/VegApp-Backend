using Backend_almog.DTO;
using Backend_almog.Services.ProductSer;
using Backend_almog.Services.SupplierSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_almog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return BadRequest();

            return Ok(product); 
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProduct (ProductDTO productDTO)
        {
            var newProduct = await _productService.CreateProductAsync(productDTO);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct!.ProductId }, newProduct);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct (int id,ProductDTO productDTO)
        {
            if (id != productDTO.ProductId) return BadRequest("Product ID mismatch.");

            var updatedProduct = await _productService.UpdateProductAsync(productDTO);
            if (updatedProduct == null) return NotFound("Failed to update product.");

            return Ok(updatedProduct);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
