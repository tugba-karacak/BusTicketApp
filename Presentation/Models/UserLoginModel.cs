using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class UserLoginModel
    {
        [EmailAddress(ErrorMessage ="Lütfen email formatında giriniz")]
        [Required(ErrorMessage ="Email alanı gereklidir")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Parola alanı gereklidir")]
        public string Password { get; set; }
    }
}
