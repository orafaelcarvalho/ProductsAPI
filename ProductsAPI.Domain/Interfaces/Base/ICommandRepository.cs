using System.Threading.Tasks;

namespace ProductsAPI.Domain.Interfaces.Base
{
    public interface ICommandRepository<T>
    {
        Task AddAsync(T obj);

        Task UpdateAsync(T obj);

        Task DeleteAsync(T obj);
    }
}
