using SupllyHub.Business.Models;

namespace SupllyHub.Business.Interfaces.Repository;
public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier> GetSupplierAddress(Guid id);
    Task<Supplier> GetSupplierProductAddress(Guid id);
}