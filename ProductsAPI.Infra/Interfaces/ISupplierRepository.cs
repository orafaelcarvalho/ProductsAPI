using ProductsAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Infra.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> GetByCodeAsync(int code);

        Task<List<Supplier>> GetAllAsync();

        Task AddAsync(Supplier supplier);

        Task UpdateAsync(Supplier supplier);

        Task DeleteAsync(Supplier supplier);
    }
}
