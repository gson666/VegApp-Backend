using Backend_almog.DTO;
using Backend_almog.Services.SupplierSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_almog.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if(supplier == null) return NotFound();

            return Ok(supplier);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNewSupplier(SupplierDTO supplierDTO)
        {
            var newSupplier = await _supplierService.CreateSupplierAsync(supplierDTO);
            return CreatedAtAction(nameof(AddNewSupplier), newSupplier);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id,SupplierDTO supplierDTO)
        {
            if (id != supplierDTO.SupplierId) return BadRequest();
            
            var updatedSupplier = await _supplierService.UpdateSupplierAsync(supplierDTO);
            if (updatedSupplier == null) return NotFound();
            return Ok(updatedSupplier);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var isDeleted = await _supplierService.DeleteSupplierAsync(id);
            if(!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
