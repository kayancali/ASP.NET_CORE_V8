using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Required]
        [Display(Name="Ürun Id")]
        public int ProductID { get; set; }

        
        [Required]
        [Display(Name="Ürün Adı")]
        public string? Name { get; set; }
        

        
        [Required]
        [Display(Name="Ürun Fiyat")]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name="Resim")]
        public string? Image { get; set; }
        
        public bool IsActive { get; set; }

        [Display(Name="Kategori")]
        [Required]

        public int? CategoryId { get; set; }
    }
}