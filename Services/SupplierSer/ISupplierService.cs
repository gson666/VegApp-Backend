using Backend_almog.DTO;

namespace Backend_almog.Services.SupplierSer
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync();
        Task<SupplierDTO?> GetSupplierByIdAsync(int supplierId);
        Task<SupplierDTO?> CreateSupplierAsync(SupplierDTO supplierDto);
        Task<SupplierDTO?> UpdateSupplierAsync(SupplierDTO supplierDto);
        Task<bool> DeleteSupplierAsync(int supplierId);
    }
}
