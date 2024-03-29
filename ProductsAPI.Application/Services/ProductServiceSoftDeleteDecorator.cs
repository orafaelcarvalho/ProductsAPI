using AutoMapper;
using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces;
using ProductsAPI.Domain.Constants;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Exceptions;
using ProductsAPI.Domain.Interfaces;
using ProductsAPI.Domain.Models;
using System.Threading.Tasks;

namespace ProductsAPI.Application.Services
{
    public class ProductServiceSoftDeleteDecorator : IProductService
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceSoftDeleteDecorator(IMapper mapper, IProductRepository productRepository)
        {
            _productService = new ProductService(mapper, productRepository);
            _productRepository = productRepository;
        }

        public async Task<Pagination<ProductDto>> GetPaginatedAsync(int quantity, int page)
        {
            return await _productService.GetPaginatedAsync(quantity, page);
        }

        public async Task<ProductDto> GetByCodeAsync(int code)
        {
            return await _productService.GetByCodeAsync(code);
        }

        public async Task<ProductDto> GetByCodeDapperAsync(int code)
        {
            return await _productService.GetByCodeDapperAsync(code);
        }

        public async Task<ProductDto> RegisterAsync(RegisterProductModel model)
        {
            return await _productService.RegisterAsync(model);
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductModel model)
        {
            return await _productService.UpdateAsync(model);
        }

        public async Task DeleteAsync(int code)
        {
            Product product = await _productRepository.GetByCodeAsync(code);
            if (product is null)
            {
                throw new RecordNotFoundException("Product", Messages.RecordNotFound);
            }
            product.MarkAsDeleted();
            await _productRepository.UpdateAsync(product);
        }
    }
}
