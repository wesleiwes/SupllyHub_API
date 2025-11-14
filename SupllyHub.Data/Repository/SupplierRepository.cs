using Microsoft.EntityFrameworkCore;
using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Models;
using SupllyHub.Data.Context;

namespace SupllyHub.Data.Repository;
public class SupplierRepository(MyDbContext context) : Repository<Supplier>(context), ISupplierRepository
{
    public async Task<Supplier> GetSupplierAddress(Guid id) =>
        await Context.Suppliers.AsNoTracking().Include(s => s.Address).FirstOrDefaultAsync(a => a.Id == id) ??
        new();

    public async Task<Supplier> GetSupplierProductAddress(Guid id) =>
        await Context.Suppliers.AsNoTracking().Include(p => p.Products).Include(a => a.Address).FirstOrDefaultAsync(c => c.Id == id) ??
        new();
}