using System.ComponentModel.DataAnnotations;

namespace Port_web.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }

    }
}
