using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Application.Interfaces.Base
{
    public interface IQueryService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByCodeAsync(int code);
    }
}
