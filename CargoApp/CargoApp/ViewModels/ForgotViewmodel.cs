using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoApp.ViewModels
{
    public class ForgotViewmodel
    {   
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz!")]
        [EmailAddress(ErrorMessage = "Email Geçeriz!")]
        public string mail { get; set; }
    }
}