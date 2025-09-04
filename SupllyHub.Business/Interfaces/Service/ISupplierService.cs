using SupllyHub.Business.Models;

namespace SupllyHub.Business.Interfaces.Service;
public interface ISupplierService : IDisposable
{
    Task<bool> Add(Supplier supplier);
    Task<bool> Delete(Guid id);
    Task<bool> Update(Supplier supplier);
    Task UpdateAddres(Address address);
}