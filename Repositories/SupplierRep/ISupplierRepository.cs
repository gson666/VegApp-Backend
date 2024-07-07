using Backend_almog.Models;

namespace Backend_almog.Repositories.SupplierRep
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(int supplierId);
        Task<Supplier?> CreateSupplierAsync(Supplier supplier);
        Task<Supplier?> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int supplierId);
    }
}
