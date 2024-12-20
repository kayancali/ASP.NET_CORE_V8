using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models

{
    public class UserInfo
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Ad alan zorunlu")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Telefon zorunlu")]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="Emailzorunlu")]
        [EmailAddress(ErrorMessage ="Hatalı Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Katılım seçiniz")]
        public bool? WillAttend { get; set; }
    }
}