using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterVİewModel
    {

        [Required]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name { get; set; }



        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email { get; set;}

        [Required]  
        [StringLength(10, ErrorMessage = "{0} alanı en  az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }


        [Required]  
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola eşleşmedi")]
        [Display(Name = "Parola Tekrar")]
        public string? ConfirmPassword { get; set; }
    }
}