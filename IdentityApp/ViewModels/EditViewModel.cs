using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.ViewModels
{
    public class EditViewModel
    {   
        public string? Id { get; set; }

        public string? FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; } 

       
        [DataType(DataType.Password)]
        public string? Password { get; set; } 

        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Parola eşleşmiyor")]
        public string? ConfirmPassword { get; set; } 

        public IList<string>? SelectedRoles { get; set; }

    }
}