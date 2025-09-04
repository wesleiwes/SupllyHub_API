using SupllyHub.Business.Models;

namespace SupllyHub.Business.Interfaces.Repository;
public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductBySupllier(Guid fornecedorId);
    Task<IEnumerable<Product>> GetProductsSuplliers();
    Task<Product> GetProductSupplier(Guid id);
}