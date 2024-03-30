using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Domain.Interfaces
{
    public interface IProductRepository : ICommandRepository<Product>, IQueryRepository<Product>
    {
        Task<Product> GetByCodeDapperAsync(int code);
        Task<List<Product>> GetPaginatedAsync(int quantity, int page);
    }
}
