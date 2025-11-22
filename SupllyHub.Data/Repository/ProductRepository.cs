using Microsoft.EntityFrameworkCore;
using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Models;
using SupllyHub.Data.Context;

namespace SupllyHub.Data.Repository;
public class ProductRepository(MyDbContext context) : Repository<Product>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductBySupllier(Guid supplierId) =>
        await Get(p => p.SupplierId == supplierId);

    public async Task<IEnumerable<Product>> GetProductsSuplliers() =>
        await Context.Products.AsNoTracking().Include(f => f.Supplier)
                                             .OrderBy(p => p.Name)
                                             .ToListAsync();

    public async Task<Product> GetProductSupplier(Guid id) =>
        await Context.Products.AsNoTracking().Include(f => f.Supplier).FirstOrDefaultAsync(p => p.Id == id) ??
        new();
}