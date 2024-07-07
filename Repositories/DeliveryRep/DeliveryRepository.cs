using Backend_almog.Data;
using Backend_almog.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_almog.Repositories.DeliveryRep
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly Dal _context;

        public DeliveryRepository(Dal context)
        {
            _context = context;
        }

        public async Task<Delivery> CreateDeliveryAsync(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            return delivery;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveriesAsync()
        {
            return await _context.Deliveries
                .Include(d => d.Supplier)
                .Include(d => d.DeliveryItems)
                .ThenInclude(di => di.Product)
                .ToListAsync();
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int deliveryId)
        {
            return await _context.Deliveries
                 .Include(d => d.Supplier)
                 .Include(d => d.DeliveryItems)
                 .ThenInclude(di => di.Product)
                 .FirstOrDefaultAsync(d => d.DeliveryId == deliveryId);
        }


        public async Task<bool?> DeleteDeliveryAsync(int deliveryId)
        {
            var delivery = await _context.Deliveries.FindAsync(deliveryId);
            if (delivery == null) return null;

            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
            return true;
        }
        
        

        public async Task<Delivery?> UpdateDeliveryAsync(Delivery delivery)
        {
            var existingDelivery = await _context.Deliveries
                                  .Include(d => d.DeliveryItems)
                                  .FirstOrDefaultAsync(d => d.DeliveryId == delivery.DeliveryId);

            if (existingDelivery == null) return null;

            existingDelivery.DeliveryDate = delivery.DeliveryDate;
            existingDelivery.SupplierId = delivery.SupplierId;
            existingDelivery.DeliveryItems.Clear();

            foreach (var item in delivery.DeliveryItems)
            {
                existingDelivery.DeliveryItems.Add(item);
            }

            await _context.SaveChangesAsync();

            return existingDelivery;
        }
    }
}
