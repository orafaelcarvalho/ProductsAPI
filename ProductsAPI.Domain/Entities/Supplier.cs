using ProductsAPI.Domain.Models;
using ProductsAPI.Domain.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Domain.Entities
{
    [Table("supplier")]
    public class Supplier : BaseEntity
    {
        [Column("description", TypeName = "NVARCHAR(50)")]
        public string Description { get; private set; }

        [Column("cnpj", TypeName = "NVARCHAR(14)")]
        public string CNPJ { get; private set; }

        protected Supplier() { }

        public Supplier(int code, string description, string cnpj)
        {
            SupplierValidator.ValidateCode(code);
            SupplierValidator.ValidateDescription(description);
            SupplierValidator.ValidateCNPJ(cnpj);
            
            Code = code;
            Description = description;
            CNPJ = cnpj;
        }

        public Supplier(RegisterSupplierModel model)
        {
            SupplierValidator.ValidateDescription(model.Description);
            SupplierValidator.ValidateCNPJ(model.CNPJ);
            
            Description = model.Description;
            CNPJ = model.CNPJ;
        }

        public void Update(UpdateSupplierModel model)
        {
            SupplierValidator.ValidateDescription(model.Description);
            SupplierValidator.ValidateCNPJ(model.CNPJ);
            
            Description = model.Description;
            CNPJ = model.CNPJ;
        }
    }
}
