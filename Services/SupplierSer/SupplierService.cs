using AutoMapper;
using Backend_almog.DTO;
using Backend_almog.Models;
using Backend_almog.Repositories.SupplierRep;

namespace Backend_almog.Services.SupplierSer
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository,IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierDTO?> CreateSupplierAsync(SupplierDTO supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            var newProduct = await _supplierRepository.CreateSupplierAsync(supplier);
            return _mapper.Map<SupplierDTO?>(newProduct);
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            return await _supplierRepository.DeleteSupplierAsync(supplierId);
        }

        public async Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return _mapper.Map<IEnumerable<SupplierDTO>>(suppliers);
        }

        public async Task<SupplierDTO?> GetSupplierByIdAsync(int supplierId)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(supplierId);
            return _mapper.Map<SupplierDTO>(supplier);
        }

        public async Task<SupplierDTO?> UpdateSupplierAsync(SupplierDTO supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            var updatedSupplier = await _supplierRepository.UpdateSupplierAsync(supplier);
            return _mapper.Map<SupplierDTO?>(updatedSupplier);
        }
    }
}
