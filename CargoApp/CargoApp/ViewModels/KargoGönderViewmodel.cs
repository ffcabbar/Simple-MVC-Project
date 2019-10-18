using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoApp.ViewModels
{
    public class KargoGönderViewmodel
    {   
        [Required]
        public string cargonumber { get; set; }

        [Required]
        public int kategoriler { get; set; }

        [Required]
        public int statuler { get; set; }

    }
}