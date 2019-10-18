using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoApp.Models
{
    public class CargoProcess
    {
        [Key]
        public int CargoProcessId { get; set; }
        public string Explanation { get; set; }

        public int CargoId { get; set; } //Fk  *One-to-one  
        public int CargoStatusId { get; set; } //Fk  *One-to-one

        // Burası program anında kullanılacak.
        public virtual Cargo Cargo { get; set; }
        public virtual List<CargoStatus> CargoStatus { get; set; }
    }
}