using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class FlightClass
    {
        [Key]
        public int FlightClassId { get; set; }
        //[ForeignKey("Flight")]
        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set;}
        [Required]
        public int TravelClassId { get; set; }
        public virtual TravelClass TravelClass { get; set; }
        [Required]
        [Display(Name="Total Seats")]
        public int NoOfSeats { get; set; }
    }
}
