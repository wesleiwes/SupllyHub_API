using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Models;
using SupllyHub.Data.Context;

namespace SupllyHub.Data.Repository;
public class SupplierRepository(MyDbContext context) : Repository<Supplier>(context), ISupplierRepository
{
    public Task<Supplier> GetSupplierAddress(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Supplier> GetSupplierProductAddress(Guid id)
    {
        throw new NotImplementedException();
    }
}
