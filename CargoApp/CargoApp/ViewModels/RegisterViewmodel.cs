using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CargoApp.Models;

namespace CargoApp.ViewModels
{
    public class RegisterViewmodel
    {
        [Required]  //bunun anlamı kullanıcı boş giremeyecek  Data Anno
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]  //bunun anlamı password ile kıyaslıyor 
        public string repeatpassword { get; set; } 

        [Required]
        public string phone { get; set; }

       
    }
}