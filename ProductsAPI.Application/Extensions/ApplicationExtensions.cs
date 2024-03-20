using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces;
using ProductsAPI.Application.Services;
using ProductsAPI.Domain.Entities;

namespace ProductsAPI.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>().ReverseMap();
                cfg.CreateMap<SupplierDto, Supplier>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
