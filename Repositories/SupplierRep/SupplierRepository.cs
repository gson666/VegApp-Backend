using Backend_almog.Data;
using Backend_almog.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_almog.Repositories.SupplierRep
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly Dal _context;

        public SupplierRepository(Dal context)
        {
            _context = context;
        }

        public async Task<Supplier?> CreateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var SupplierToDelete =await _context.Suppliers.FindAsync(supplierId);
            if (SupplierToDelete == null) return false;

            _context.Remove(SupplierToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Suppliers.FindAsync(supplierId);
        }

        public async Task<Supplier?> UpdateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
    }
}
