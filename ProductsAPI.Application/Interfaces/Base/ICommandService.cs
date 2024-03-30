using System.Threading.Tasks;

namespace ProductsAPI.Application.Interfaces.Base
{
    public interface ICommandService<T, R, U>
    {
        Task<T> RegisterAsync(R model);
        Task<T> UpdateAsync(U model);
        Task DeleteAsync(int code);
    }
}
