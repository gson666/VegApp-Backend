using Backend_almog.DTO;
using Backend_almog.Services.DeliverySer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_almog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveriesController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeliveries()
        {
            var deliveries = await _deliveryService.GetAllDeliveriesAsync();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryById(int id)
        {
            var delivery = await _deliveryService.GetDeliveryByIdAsync(id);
            if(delivery == null) return NotFound();

            return Ok(delivery);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDelivery(DeliveryDTO deliveryDTO)
        {
            var newDelivery = await _deliveryService.CreateDeliveryAsync(deliveryDTO);
            return CreatedAtAction(nameof(CreateDelivery),new {id = newDelivery.DeliveryId},newDelivery);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id,DeliveryDTO deliveryDTO)
        {
            if(id != deliveryDTO.DeliveryId) return BadRequest();
            
            var updatedDelivery = await _deliveryService.UpdateDeliveryAsync(deliveryDTO);
            return Ok(updatedDelivery);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var isDeleted = await _deliveryService.DeleteDeliveryAsync(id);
            if((bool)!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
