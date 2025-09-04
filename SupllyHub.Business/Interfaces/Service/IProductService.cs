using SupllyHub.Business.Models;

namespace SupllyHub.Business.Interfaces.Service;
public interface IProductService : IDisposable
{
    Task Add(Product product);
    Task Delete(Guid id);
    Task Update(Product product);
}
