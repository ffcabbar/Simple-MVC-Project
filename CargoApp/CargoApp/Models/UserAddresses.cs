using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoApp.Models
{
    public class UserAddresses
    {   [Key]
        public int UserAddressesId { get; set; }
        public string AddressName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; } //Fk  *One-to-one

        // Burası program anında kullanılacak.
        public virtual  Users User { get; set; }
    }
}