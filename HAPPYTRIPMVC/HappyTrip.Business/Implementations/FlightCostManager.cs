using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
   public class FlightCostManager:IFlightCostManager
    {
        private IFlightCostRepository  repo = null;

        public FlightCostManager(IUnitOfWork uof)
        {
            repo = uof.GetFlightCostRepository();
        }

        public void AddFlightCost(Models.FlightCost cost)
        {
            repo.Create(cost);
        }
    }
}
