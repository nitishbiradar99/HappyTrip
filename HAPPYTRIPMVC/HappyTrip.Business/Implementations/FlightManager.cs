using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
    internal class FlightManager : IFlightManager
    {
        private IFlightRepo flightRepo = null;
        private IAirlineRepo airlinerepo = null;
        private ITravelClassRepo travelclassRepo = null;
        private IFlightClassRepo flightClassRepo = null;

        public FlightManager(IUnitOfWork uow)
        {
            this.flightRepo = uow.GetFlightRepository();
            this.airlinerepo = uow.GetAirlineRepository();
            this.travelclassRepo = uow.GetTravelClassRepository();
            this.flightClassRepo = uow.GetFlightClassRepository();
        }

        public void AddFlight(Models.Flight flight)
        {
            flightRepo.Create(flight);
        }

        public IList<Models.Flight> GetFlight()
        {
            return flightRepo.All().ToList<Flight>();
        }

        public void EditFlight(Models.Flight flight)
        {
            flightRepo.Update(flight);
        }

        public void DeleteFlight(int id)
        {
            flightRepo.Delete(id);
        }

        public Models.Flight FindFlight(int id)
        {
            Flight flight = flightRepo.Find(id);
            return flight;
        }

        public List<Airline> GetAllAirline()
        {
            List<Airline> airlines = airlinerepo.All().ToList<Airline>();
            return airlines;
        }


        public List<TravelClass> GetAllTravelClass()
        {
            List<TravelClass> travelClasses = travelclassRepo.All().ToList<TravelClass>();
            return travelClasses;
        }


        public void AddFlightClass(FlightClass t)
        {
            flightClassRepo.Create(t);
        }


        public List<FlightClass> GetFlightClass()
        {
            return flightClassRepo.All().ToList<FlightClass>();
        }


        public FlightClass FindFlightClass(int id)
        {
            FlightClass flightClass = flightClassRepo.Find(id);
            return flightClass;
        }

        public void EditFlightClass(FlightClass fc)
        {
            flightClassRepo.Update(fc);
        }


        public void DeleteFlightClass(FlightClass fc)
        {
            flightClassRepo.Delete(fc);
        }
    }
}
