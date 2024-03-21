using ProductsAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByCodeAsync(int code);
        Task<Product> GetByCodeDapperAsync(int code);

        Task<List<Product>> GetPaginatedAsync(int quantity, int page);

        Task AddAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
