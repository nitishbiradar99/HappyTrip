using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Models.Common;

namespace HappyTrip.Models
{
    public class SearchInfo
    {
        public City DesitinationCity { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfPeople { get; set; }
        public int NoOfRooms { get; set; }
    }
}
