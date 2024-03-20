using ProductsAPI.Domain.Enums;
using ProductsAPI.Domain.Models;
using ProductsAPI.Domain.Validations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Domain.Entities
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("description", TypeName = "NVARCHAR(50)")]
        public string Description { get; private set; }

        [Column("status", TypeName = "int")]
        public ProductStatus Status { get; private set; }

        [Column("manufacturingdate", TypeName = "DATETIME")]
        public DateTime ManufacturingDate { get; private set; }

        [Column("expirationdate", TypeName = "DATETIME")]
        public DateTime ExpirationDate { get; private set; }

        [Column("suppliercode", TypeName = "INT")]
        public int SupplierCode { get; private set; }
        public virtual Supplier Supplier { get; private set; }        

        protected Product() { }

        public Product(int code, string description, ProductStatus status, DateTime manufacturingDate, DateTime expirationDate, int supplierId)
        {
            ProductValidator.ValidateCode(code);
            ProductValidator.ValidateDescription(description);
            ProductValidator.ValidateStatus(status);
            ProductValidator.ValidateManufacturingDate(manufacturingDate, expirationDate);
            ProductValidator.ValidateSupplierCode(supplierId);
            
            Code = code;
            Description = description;
            Status = status;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
            SupplierCode = supplierId;
        }

        public Product(RegisterProductModel model)
        {
            ProductValidator.ValidateDescription(model.Description);
            ProductValidator.ValidateStatus(model.Status);
            ProductValidator.ValidateManufacturingDate(model.ManufacturingDate, model.ExpirationDate);
            ProductValidator.ValidateSupplierCode(model.SupplierCode);
            
            Description = model.Description;
            Status = model.Status;
            ManufacturingDate = model.ManufacturingDate;
            ExpirationDate = model.ExpirationDate;
            SupplierCode = model.SupplierCode;
        }

        public void Update(UpdateProductModel model)
        {
            ProductValidator.ValidateDescription(model.Description);
            ProductValidator.ValidateStatus(model.Status);
            ProductValidator.ValidateManufacturingDate(ManufacturingDate, ExpirationDate);
            ProductValidator.ValidateSupplierCode(model.SupplierCode);
            
            Description = model.Description;
            Status = model.Status;
            ManufacturingDate = model.ManufacturingDate;
            ExpirationDate = model.ExpirationDate;
            SupplierCode = model.SupplierCode;            
        }

        public void MarkAsDeleted()
        {
            Status = ProductStatus.Inactive;
        }
    }
}
