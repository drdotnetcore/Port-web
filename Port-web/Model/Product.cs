using System.ComponentModel.DataAnnotations;

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
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "From Purchase")]
        public int FromPurchase { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        [Display(Name = "Sales Price")]
        public double SellingPrice { get; set; }
        [Required]
        [Display(Name = "Discount %")]
        [Range(1,99)]
        public int DiscountPercentage { get; set; }


    }
}
