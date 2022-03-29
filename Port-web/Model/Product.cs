using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Port_web.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Category Id")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "SKU")]
        [MaxLength(50, ErrorMessage = "SKU has to be shorter than 50 characters"),MinLength(5,ErrorMessage ="SKU has to be longer than 5 characters")]
        public string SKU { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        [Display(Name = "Sales Price")]
        public double SellingPrice { get; set; }
        [Required]
        [Display(Name = "Discount %")]
        [Range(1,99,ErrorMessage ="Must be between 1 and 99")]
        public int DiscountPercentage { get; set; }


    }
}
