using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface IFlightClassManager
    {
        void AddFlightClass(FlightClass flightClass);

        IList<FlightClass> GetFlightClass();

        void EditFlightClass(FlightClass flightClass);

        void DeleteFlightClass(int id);

        FlightClass FindFlightClass(int id);

        List<Airline> GetAllAirline();

        List<TravelClass> GetAllTravelClass();
    }
}
