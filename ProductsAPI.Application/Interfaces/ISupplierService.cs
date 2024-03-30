using ProductsAPI.Application.DTOs;
using ProductsAPI.Application.Interfaces.Base;
using ProductsAPI.Domain.Models;

namespace ProductsAPI.Application.Interfaces
{
    public interface ISupplierService : ICommandService<SupplierDto, RegisterSupplierModel, UpdateSupplierModel>, IQueryService<SupplierDto>
    {
    }
}
