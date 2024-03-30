using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces.Base;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Models;
using System.Threading.Tasks;

namespace ProductsAPI.Application.Interfaces
{
    public interface IProductService : ICommandService<ProductDto, RegisterProductModel, UpdateProductModel>, IQueryService<ProductDto>
    {
        Task<ProductDto> GetByCodeDapperAsync(int code);
        Task<Pagination<ProductDto>> GetPaginatedAsync(int quantity, int page);
    }
}
