using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces;
using ProductsAPI.Domain.Constants;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Exceptions;
using ProductsAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{quantity:int}/{page:int}")]
        public async Task<ActionResult<List<ProductDto>>> GetPaginatedProducts(int quantity, int page)
        {
            try
            {
                Pagination<ProductDto> response = await _productService.GetPaginatedAsync(quantity, page);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            try
            {
                List<ProductDto> response = await _productService.GetAllAsync();
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ProductDto>> GetProductByCode(int code)
        {
            try
            {
                ProductDto response = await _productService.GetByCodeAsync(code);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (RecordNotFoundException e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("dapper/{code}")]
        public async Task<ActionResult<ProductDto>> GetProductByCodeDapper(int code)
        {
            try
            {
                ProductDto response = await _productService.GetByCodeDapperAsync(code);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (RecordNotFoundException e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> RegisterProduct(RegisterProductModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.FillFields);
                }
                ProductDto response = await _productService.RegisterAsync(model);
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{code}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int code, UpdateProductModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status409Conflict, Messages.FillFields);
                }
                if (code != model.Code)
                {
                    throw new Exception("Dados inválidos para atualizar cadastro de produto!");
                }
                ProductDto response = await _productService.UpdateAsync(model);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (RecordNotFoundException e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteProduct(int code)
        {
            try
            {
                await _productService.DeleteAsync(code);
                return StatusCode(StatusCodes.Status200OK, Messages.DeletedSuccessfully);
            }
            catch (RecordNotFoundException e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
