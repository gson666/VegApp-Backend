using AutoMapper;
using Backend_almog.DTO;
using Backend_almog.Models;
using Backend_almog.Repositories.DeliveryRep;

namespace Backend_almog.Services.DeliverySer
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository,IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }
        public async Task<DeliveryDTO> CreateDeliveryAsync(DeliveryDTO deliveryDTO)
        {
            var delivery = _mapper.Map<Delivery>(deliveryDTO);
            var newDelivery = await _deliveryRepository.CreateDeliveryAsync(delivery);
            return _mapper.Map<DeliveryDTO>(newDelivery);
        }

        public async Task<bool?> DeleteDeliveryAsync(int deliveryId)
        {
            return await _deliveryRepository.DeleteDeliveryAsync(deliveryId);
        }

        public async Task<IEnumerable<DeliveryDTO>> GetAllDeliveriesAsync()
        {
            var deliveries = await _deliveryRepository.GetAllDeliveriesAsync();
            return _mapper.Map<IEnumerable<DeliveryDTO>>(deliveries);
        }

        public async Task<DeliveryDTO> GetDeliveryByIdAsync(int deliveryId)
        {
            var delivery = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
            return _mapper.Map<DeliveryDTO>(delivery);
        }

        public async Task<DeliveryDTO> UpdateDeliveryAsync(DeliveryDTO deliveryDTO)
        {
            var delivery = _mapper.Map<Delivery>(deliveryDTO);
            var updatedDelivery = await _deliveryRepository.UpdateDeliveryAsync(delivery);
            return _mapper.Map<DeliveryDTO>(updatedDelivery);
        }
    }
}
