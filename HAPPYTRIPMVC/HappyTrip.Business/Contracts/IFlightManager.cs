using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface IFlightManager
    {
        void AddFlight(Flight flight);
        IList<Flight> GetFlight();
        void EditFlight(Flight flight);
        void DeleteFlight(int id);

        Flight FindFlight(int id);
        List<Airline> GetAllAirline();
        List<TravelClass> GetAllTravelClass();

        void AddFlightClass(FlightClass t);
        List<FlightClass> GetFlightClass();

        FlightClass FindFlightClass(int id);
        void EditFlightClass(FlightClass fc);
        void DeleteFlightClass(FlightClass fc);

    }
}
