using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models.AirTravel
{
    class FlightCost
    {
        #region Properties of the class

        public TravelClass travelClass { get; set; }
        public decimal CostPerTicket { get; set; }

        #endregion
    }
}
