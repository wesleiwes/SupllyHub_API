using AutoMapper;
using SupllyHub.API.Model;
using SupllyHub.Business.Models;

namespace SupllyHub.API.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Supplier, SupplierModel>().ReverseMap();
        CreateMap<Address, AddressModel>().ReverseMap();
        CreateMap<Product, ProductModel>().ReverseMap();
    }
}
