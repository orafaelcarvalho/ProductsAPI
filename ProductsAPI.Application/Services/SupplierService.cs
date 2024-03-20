using AutoMapper;
using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces;
using ProductsAPI.Domain.Constants;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Exceptions;
using ProductsAPI.Domain.Models;
using ProductsAPI.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            List<Supplier> suppliers = await _supplierRepository.GetAllAsync();
            return _mapper.Map<List<Supplier>, List<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto> GetByCodeAsync(int code)
        {
            Supplier supplier = await _supplierRepository.GetByCodeAsync(code);
            if (supplier is null)
            {
                throw new RecordNotFoundException("Supplier", Messages.RecordNotFound);
            }
            return _mapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task<SupplierDto> RegisterAsync(RegisterSupplierModel model)
        {
            Supplier supplier = new Supplier(model);
            await _supplierRepository.AddAsync(supplier);
            return _mapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task<SupplierDto> UpdateAsync(UpdateSupplierModel model)
        {
            Supplier supplier = await _supplierRepository.GetByCodeAsync(model.Code);
            if (supplier is null)
            {
                throw new RecordNotFoundException("Supplier", Messages.RecordNotFound);
            }
            supplier.Update(model);
            await _supplierRepository.UpdateAsync(supplier);
            return _mapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task DeleteAsync(int code)
        {
            try
            {
                Supplier supplier = await _supplierRepository.GetByCodeAsync(code);
                if (supplier is null)
                {
                    throw new RecordNotFoundException("Supplier", Messages.RecordNotFound);
                }
                await _supplierRepository.DeleteAsync(supplier);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
