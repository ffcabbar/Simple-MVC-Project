using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoApp.ViewModels
{
    public class ResetPasswordViewmodel
    {   
        [Required]
        public string newpassword { get; set; }
        
        [Required]
        [Compare("newpassword", ErrorMessage = "The newpassword and confirmation password do not match.")]
        public string confirmpassword { get; set; }
    }
}