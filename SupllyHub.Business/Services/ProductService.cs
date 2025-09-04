using SupllyHub.Business.Interfaces;
using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Interfaces.Service;
using SupllyHub.Business.Models;
using SupllyHub.Business.Models.Validation;


namespace SupllyHub.Business.Services;
public class ProductService(IUser user,
                            IProductRepository productRepository,
                            INotifier notifier) : BaseService(notifier), IProductService
{
    private readonly IUser _user = user;
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Add(Product product)
    {

        if (!RunValidation(new ProductValidation(), product))
        {
            return;
        }

        await _productRepository.Add(product);
    }

    public async Task Delete(Guid id) =>
        await _productRepository.Delete(id);


    public void Dispose() =>
        _productRepository?.Dispose();


    public async Task Update(Product product)
    {
        if (!RunValidation(new ProductValidation(), product))
        {
            return;
        }

        await _productRepository.Update(product);
    }
}
