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
        public int CategoryId { get; set; }
        [Required]
        public int FromPurchase { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public double SellingPrice { get; set; }
        [Required]
        public int DiscountPercentage { get; set; }


    }
}
