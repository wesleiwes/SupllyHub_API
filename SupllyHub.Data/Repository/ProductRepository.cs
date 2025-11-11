using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Models;
using SupllyHub.Data.Context;

namespace SupllyHub.Data.Repository;
public class ProductRepository(MyDbContext context) : Repository<Product>(context), IProductRepository
{
    public Task<IEnumerable<Product>> GetProductBySupllier(Guid fornecedorId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductsSuplliers()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductSupplier(Guid id)
    {
        throw new NotImplementedException();
    }
}
