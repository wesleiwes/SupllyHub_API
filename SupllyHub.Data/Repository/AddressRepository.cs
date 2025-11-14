using Microsoft.EntityFrameworkCore;
using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Models;
using SupllyHub.Data.Context;

namespace SupllyHub.Data.Repository;
public class AddressRepository(MyDbContext context) : Repository<Address>(context), IAddressRepository
{
    public async Task<Address> GetAddressBySupplier(Guid supplierId) =>
        await Context.Addresses.AsNoTracking().FirstOrDefaultAsync(s => s.SupplierId == supplierId) ??
        new();
}