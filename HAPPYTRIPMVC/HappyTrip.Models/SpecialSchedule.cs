using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
   public  class SpecialSchedule
    {
        public int SpecialScheduleId { get; set; }
        public int FlightID { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public int RouteId { get; set; }
        [Required]
        public int EcoCost { get; set;}
        [Required]
        public int BusinessCost { get; set;}
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int DurationInMins { get; set; }
        public bool IsActive { get; set; }
    }
}
