using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupllyHub.API.Model;
using SupllyHub.Business.Interfaces.Repository;

namespace SupllyHub.API.Controllers;

[Route("api/[fornecedores]")]
public abstract class SuplliersController(ISupplierRepository supplierRepository, IMapper mapper) : MainController
{
    private readonly ISupplierRepository _supplierRepository = supplierRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<SupplierModel>> GetAll()
    {
        IEnumerable<SupplierModel> fornecedores =
            _mapper.Map<IEnumerable<SupplierModel>>(await _supplierRepository.GetAll());
        return fornecedores;
    }
}
