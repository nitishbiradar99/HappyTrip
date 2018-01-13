using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
   public  class TravelClass
    {
        public int TravelClassId { get; set; }
        [Required]
        [Display(Name="Travel Class")]
        public string TravelClassName { get; set; }
    }
}
