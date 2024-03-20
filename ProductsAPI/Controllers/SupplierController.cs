using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces;
using ProductsAPI.Domain.Constants;
using ProductsAPI.Domain.Exceptions;
using ProductsAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliersAPI.API.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierDto>>> GetAllSuppliers()
        {
            try
            {
                List<SupplierDto> response = await _supplierService.GetAllAsync();
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<SupplierDto>> GetSupplierByCode(int code)
        {
            try
            {
                SupplierDto response = await _supplierService.GetByCodeAsync(code);
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
        public async Task<ActionResult<SupplierDto>> RegisterSupplier(RegisterSupplierModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status409Conflict, Messages.FillFields);
                }
                SupplierDto response = await _supplierService.RegisterAsync(model);
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{code}")]
        public async Task<ActionResult<SupplierDto>> UpdateSupplier(int code, UpdateSupplierModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status409Conflict, Messages.FillFields);
                }
                if (code != model.Code)
                {
                    throw new Exception("Dados inválidos para atualizar cadastro de fornecedor!");
                }
                SupplierDto response = await _supplierService.UpdateAsync(model);
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
        public async Task<ActionResult> DeleteSupplier(int code)
        {
            try
            {
                await _supplierService.DeleteAsync(code);
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
