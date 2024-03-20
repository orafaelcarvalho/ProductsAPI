using ProductsAPI.Domain.Enums;
using System;

namespace ProductsAPI.Application.DTOs
{
    public class ProductDto
    {
        public int Code { get; set; }

        public string Description { get; set; }

        public ProductStatus Status { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int SupplierCode { get; set; }
    }
}
