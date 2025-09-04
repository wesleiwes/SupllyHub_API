using SupllyHub.Business.Models;

namespace SupllyHub.Business.Interfaces.Repository;
public interface IAddressRepository : IRepository<Address>
{
    Task<Address> GetAddressBySupplier(Guid fornecedorId);
}