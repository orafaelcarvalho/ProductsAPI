using ProductsAPI.Domain.Exceptions;

namespace ProductsAPI.Domain.Validations
{
    public static class SupplierValidator
    {
        public static void ValidateCode(int code)
        {
            if (code == 0)
                throw new InvalidEntityException("Fornecedor", "Código inválido.");
        }

        public static void ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidEntityException("Fornecedor", "Descrição não pode ser nulo.");
        }

        public static void ValidateCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj) || !CNPJValidator.ValidateCNPJ(cnpj))
                throw new InvalidEntityException("Fornecedor", "CNPJ inválido.");
        }
    }
}
