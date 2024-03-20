using ProductsAPI.Application.DTOs;
using ProductsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierDto> GetByCodeAsync(int code);
        Task<List<SupplierDto>> GetAllAsync();
        Task<SupplierDto> RegisterAsync(RegisterSupplierModel model);
        Task<SupplierDto> UpdateAsync(UpdateSupplierModel model);
        Task DeleteAsync(int code);
    }
}
