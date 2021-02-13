using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        public string Surname { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email giriniz")]
        [Required(ErrorMessage = "Email adresi gereklidir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola gereklidir")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
