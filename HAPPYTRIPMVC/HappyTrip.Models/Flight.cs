using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HappyTrip.Models
{
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }
        [Required(ErrorMessage="Please Enter the Flight Name")]
        [Display(Name="Flight Name")]
        public string Name { get; set; }
        [Required]
        public int AirlineId { get; set; }
        public virtual Airline Airline { get; set; }
        public List<FlightClass> classes { get; set; }
        public virtual List<Schedule> Schedules { get; set; }
    }
}
