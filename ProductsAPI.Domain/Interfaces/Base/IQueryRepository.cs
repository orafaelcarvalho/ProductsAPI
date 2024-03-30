using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Domain.Interfaces.Base
{
    public interface IQueryRepository<T>
    {
        Task<T> GetByCodeAsync(int code);
        Task<List<T>> GetAllAsync();
    }
}
