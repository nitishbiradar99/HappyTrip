using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
    internal class FlightClassManager : IFlightClassManager
    {
        private IAirlineRepo airlinerepo = null;
        private ITravelClassRepo travelclassRepo = null;
        private IFlightClassRepo flightClassRepo = null;

        public FlightClassManager(IUnitOfWork uow)
        {
            this.airlinerepo = uow.GetAirlineRepository();
            this.travelclassRepo = uow.GetTravelClassRepository();
            this.flightClassRepo = uow.GetFlightClassRepository();
        }

        public void AddFlightClass(Models.FlightClass flightClass)
        {
            flightClassRepo.Create(flightClass);
        }

        public IList<Models.FlightClass> GetFlightClass()
        {
            return flightClassRepo.All().ToList<Models.FlightClass>();
        }

        public void EditFlightClass(Models.FlightClass flightClass)
        {
            flightClassRepo.Update(flightClass);
        }

        public void DeleteFlightClass(int id)
        {
            flightClassRepo.Delete(id);
        }

        public Models.FlightClass FindFlightClass(int id)
        {
            Models.FlightClass flightClass = flightClassRepo.Find(id);
            return flightClass;
        }

        public List<Models.Airline> GetAllAirline()
        {
            return airlinerepo.All().ToList<Models.Airline>();
        }

        public List<Models.TravelClass> GetAllTravelClass()
        {
            return travelclassRepo.All().ToList<Models.TravelClass>();
        }
    }
}
