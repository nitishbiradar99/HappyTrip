using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace HappyTrip.Models.AirTravel
{
    public class Airline
    {
        [Key]
        public int AirlineId { get; set; }

        [Required]
        public string AirlineName { get; set; }

        [Required]
        public string AirlineLogo { get; set; }

        [Required]
        public string AirlineCode { get; set; }
    }
}
