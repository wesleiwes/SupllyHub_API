using SupllyHub.Business.Interfaces.Repository;
using SupllyHub.Data.Context;
using SupllyHub.Data.Repository;

namespace SupllyHub.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<MyDbContext>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
