using Backend_almog.Models;

namespace Backend_almog.Repositories.DeliveryRep
{
    public interface IDeliveryRepository
    {
        Task<IEnumerable<Delivery>> GetAllDeliveriesAsync();
        Task<Delivery> GetDeliveryByIdAsync(int deliveryId);
        Task<Delivery> CreateDeliveryAsync(Delivery delivery);
        Task<Delivery?> UpdateDeliveryAsync(Delivery delivery);
        Task<bool?> DeleteDeliveryAsync(int deliveryId);
    }
}
