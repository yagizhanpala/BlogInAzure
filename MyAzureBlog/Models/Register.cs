using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAzureBlog.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor")]
        [Display(Name = "Şifre doğrula")]
        public string ConfirmPassword { get; set; }
    }
}