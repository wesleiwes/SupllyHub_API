using SupllyHub.Business.Interfaces;
using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Business.Interfaces.Service;
using SupllyHub.Business.Models;
using SupllyHub.Business.Models.Validation;

namespace SupllyHub.Business.Services;
public class SupplierService(ISupplierRepository supplierRepository,
                             IAddressRepository addressRepository,
                             INotifier notifier) : BaseService(notifier), ISupplierService
{
    private readonly ISupplierRepository _supplierRepository = supplierRepository;
    private readonly IAddressRepository _addressRepository = addressRepository;

    public async Task<bool> Add(Supplier supplier)
    {
        if (!RunValidation(new SupplierValidation(), supplier) ||
                !RunValidation(new AddressValidation(), supplier.Address))
        {
            return false;
        }

        bool hasSupplier = _supplierRepository.Get(s => s.Document == supplier.Document).Result.Any();

        if (hasSupplier)
        {
            Notify("Já existe um fornecedor com este documento informado.");
            return false;
        }

        await _supplierRepository.Add(supplier);
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        if (_supplierRepository.GetSupplierProductAddress(id).Result.Products.Any())
        {
            Notify("O fornecedor possui produtos cadastrados!");
            return false;
        }

        Task<Address> address = _addressRepository.GetAddressBySupplier(id);

        if (address is not null)
        {
            await _addressRepository.Delete((await address).Id);
        }

        await _supplierRepository.Delete(id);
        return true;
    }

    public void Dispose()
    {
        _supplierRepository?.Dispose();
        _addressRepository?.Dispose();
    }

    public async Task<bool> Update(Supplier supplier)
    {
        if (RunValidation(new SupplierValidation(), supplier))
        {
            return false;
        }

        if (_supplierRepository.Get(f => f.Document == supplier.Document && f.Id != supplier.Id).Result.Any())
        {
            Notify("Já existe um fornecedor com este documento infomado.");
            return false;
        }

        await _supplierRepository.Update(supplier);
        return true;

    }

    public async Task UpdateAddres(Address address)
    {
        if (!RunValidation(new AddressValidation(), address))
        {
            return;
        }

        await _addressRepository.Update(address);
    }
}
