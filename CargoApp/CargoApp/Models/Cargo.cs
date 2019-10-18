using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoApp.Models
{
    public class Cargo
    {   [Key]
        public int CargoId { get; set; }
        public string CargoNumber { get; set; }

        public int CategoryId { get; set; } //Fk  *One-to-one
        public int CargoStatusId { get; set; } //Fk  *One-to-one

        // Burası program anında kullanılacak.
        public virtual Categories Category { get; set; } // virtual demek code tarafında bunların ilişkili olduğu tablolarıda getir demektir. çünkü zaten otomotik aradaki ilişkiyi kuruyor ilişkileri veritabanında code firtst kuruyor. ama code atrafında virtual ve lazyloadingi aktif etmek lazım.
        public virtual CargoStatus CargoStatus { get; set; } 
    }
}