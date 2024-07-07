using Backend_almog.DTO;

namespace Backend_almog.Services.DeliverySer
{
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryDTO>> GetAllDeliveriesAsync();
        Task<DeliveryDTO> GetDeliveryByIdAsync(int deliveryId);
        Task<DeliveryDTO> CreateDeliveryAsync(DeliveryDTO deliveryDTO);
        Task<DeliveryDTO> UpdateDeliveryAsync(DeliveryDTO deliveryDTO);
        Task<bool?> DeleteDeliveryAsync(int deliveryId);
    }
}
