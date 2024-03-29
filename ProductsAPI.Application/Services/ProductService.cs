using AutoMapper;
using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces;
using ProductsAPI.Domain.Constants;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Enums;
using ProductsAPI.Domain.Exceptions;
using ProductsAPI.Domain.Interfaces;
using ProductsAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Pagination<ProductDto>> GetPaginatedAsync(int quantity, int page)
        {
            List<Product> products = await _productRepository.GetPaginatedAsync(quantity, page);
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            Pagination<ProductDto> response = new Pagination<ProductDto>(productsDto.Count, productsDto);
            return response;
        }

        public async Task<ProductDto> GetByCodeAsync(int code)
        {
            Product product = await _productRepository.GetByCodeAsync(code);
            if (product is null || 
                product.Status == ProductStatus.Inactive)
            {
                throw new RecordNotFoundException("Product", Messages.RecordNotFound);
            }
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> GetByCodeDapperAsync(int code)
        {
            Product product = await _productRepository.GetByCodeDapperAsync(code);
            if (product is null)
            {
                throw new RecordNotFoundException("Product", Messages.RecordNotFound);
            }
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> RegisterAsync(RegisterProductModel model)
        {
            Product product = new Product(model);
            await _productRepository.AddAsync(product);
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductModel model)
        {
            Product product = await _productRepository.GetByCodeAsync(model.Code);
            if (product is null)
            {
                throw new RecordNotFoundException("Product", Messages.RecordNotFound);
            }
            product.Update(model);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task DeleteAsync(int code)
        {
            try
            {
                Product product = await _productRepository.GetByCodeAsync(code);
                if (product is null)
                {
                    throw new RecordNotFoundException("Product", Messages.RecordNotFound);
                }                
                await _productRepository.DeleteAsync(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
