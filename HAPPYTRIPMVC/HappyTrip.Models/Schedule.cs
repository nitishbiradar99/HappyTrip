using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }
        //[ForeignKey("flight")]
        public int FlightID { get; set; }
        [ForeignKey("FlightID")]
        public virtual Flight Flight { get; set; }
        [Required]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        [Required]
        public int DurationInMins { get; set; }
        public bool IsActive { get; set; }
        public virtual List<FlightCost> flightCosts { get; set; }
    }
}
