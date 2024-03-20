using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Enums;
using ProductsAPI.Domain.Exceptions;
using System;

namespace ProductsAPI.Domain.Validations
{
    public static class ProductValidator
    {
        public static void ValidateCode(int code)
        {
            if (code == 0)
                throw new InvalidEntityException("Produto", "Código inválido.");
        }

        public static void ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidEntityException("Produto", "Descrição não pode ser nulo.");
        }

        public static void ValidateStatus(ProductStatus status)
        {
            if (status != ProductStatus.Active && status != ProductStatus.Inactive)
                throw new InvalidEntityException("Produto", "Situação inválida.");
        }

        public static void ValidateManufacturingDate(DateTime manufacturingDate, DateTime expirationDate)
        {
            if (manufacturingDate.Date >= expirationDate.Date)
                throw new InvalidEntityException("Produto", "A data de fabricação não pode ser maior ou igual a data de validade.");
        }

        public static void ValidateSupplierCode(int supplierCode)
        {
            if (supplierCode == 0)
                throw new InvalidEntityException("Produto", "Código do fornecedor inválido.");
        }
    }
}
