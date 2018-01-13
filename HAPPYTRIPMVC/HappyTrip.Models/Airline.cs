using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Airline
    {
        public int AirlineId { get; set; }
        [Required(ErrorMessage="Please Enter the Airline Name")]
        [Display(Name="Airline")]
        public string AirlineName { get; set; }
        [Required()]
        [Display(Name="Airline Code")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Airline Logo")]
        public string Logo { get; set; }
        //public virtual List<Flight> flights { get; set;}
    }
}
