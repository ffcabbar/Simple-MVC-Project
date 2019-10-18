using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoApp.Models
{
    public class CargoStatus
    {   [Key]
        public int CargoStatusId { get; set; }
        public string StatusName { get; set; }
    }
}