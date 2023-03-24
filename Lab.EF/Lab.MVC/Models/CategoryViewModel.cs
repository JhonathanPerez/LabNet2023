using System.ComponentModel.DataAnnotations;

namespace Lab.MVC.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Nombre categoría")]
        [Required]
        public string categoryName { get; set; }

        [Display(Name = "Descripción categoría")]
        [Required]
        public string categoryDescription { get; set; }
    }
}