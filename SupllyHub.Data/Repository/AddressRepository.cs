using Microsoft.EntityFrameworkCore;
using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Models;
using SupllyHub.Data.Context;

namespace SupllyHub.Data.Repository;
public class AddressRepository(MyDbContext context) : Repository<Address>(context), IAddressRepository
{
    public Task<Address> GetAddressBySupplier(Guid supplierId) =>
        context.Addresses.AsNoTracking().FirstOrDefaultAsync(s => s.SupplierId == supplierId);
}