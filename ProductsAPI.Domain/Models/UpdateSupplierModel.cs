using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Domain.Models
{
    public class UpdateSupplierModel
    {
        [Display(Name = "Code")]
        [Required]
        public int Code { get; set; }

        [Display(Name = "Description")]
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Description { get; set; }

        [Display(Name = "CNPJ")]
        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string CNPJ { get; set; }
    }
}
