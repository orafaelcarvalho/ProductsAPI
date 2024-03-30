using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Interfaces.Base;

namespace ProductsAPI.Domain.Interfaces
{
    public interface ISupplierRepository : ICommandRepository<Supplier>, IQueryRepository<Supplier>
    {
    }
}
