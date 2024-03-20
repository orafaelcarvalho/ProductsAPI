using ProductsAPI.Application.DTOs;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Models;
using System.Threading.Tasks;

namespace ProductsAPI.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetByCodeAsync(int code);
        Task<ProductDto> GetByCodeDapperAsync(int code);
        Task<Pagination<ProductDto>> GetPaginatedAsync(int quantity, int page);
        Task<ProductDto> RegisterAsync(RegisterProductModel model);
        Task<ProductDto> UpdateAsync(UpdateProductModel model);
        Task DeleteAsync(int code);
    }
}
