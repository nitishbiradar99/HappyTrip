using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
   public class ScheduleViewModel
    {
        public int FromCity { get; set; }
        public int ToCity { get; set; }
        public int Flight { get; set; }
        public TimeSpan DepartureTime { get; set;}
        public FlightCost Business { get; set; }
        public FlightCost Economy { get; set; }
        public TimeSpan ArrivalTime { get; set;}
        public  int DurationInMins { get; set;}

    }
}
