using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        [Required]
        public string TicketNo { get; set; }
        [Required]
        public string FlightNo { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public DateTime JourneyDate { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Fare { get; set; }
        
    }
}
