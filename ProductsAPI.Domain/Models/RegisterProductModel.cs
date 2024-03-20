using ProductsAPI.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Domain.Models
{
    public class RegisterProductModel
    {
        [Display(Name = "Description")]
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Description { get; set; }

        [Display(Name = "Product Status (1=Active, 0=Inactive)")]
        [Required]
        public ProductStatus Status { get; set; }

        [Display(Name = "Manufacturing Date")]
        [Required]
        public DateTime ManufacturingDate { get; set; }

        [Display(Name = "Expiration Date")]
        [Required]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Supplier Code")]
        [Required]
        public int SupplierCode { get; set; }
    }
}
