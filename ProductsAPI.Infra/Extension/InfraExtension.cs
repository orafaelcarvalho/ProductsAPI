using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Domain.Interfaces;
using ProductsAPI.Infra.DataContext;
using ProductsAPI.Infra.DbSession;
using ProductsAPI.Infra.Repositories;
using SupplierAPI.Infra.Repositories;

namespace ProductsAPI.Infra.Extension
{
    public static class InfraExtension
    {
        public static IServiceCollection AddInfraExtension(this IServiceCollection services)
        {

            services.AddDbContext<ProductsDataContext>(ServiceLifetime.Transient);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped<IDbSessionDapper, DbSessionDapper>();

            return services;
        }
    }
}
