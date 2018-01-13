using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
   public interface IScheduleManager
    {
        //void AddSchedule(Schedule schedule);
        //IList<Schedule> GetSchedule();
        //void EditSchedule(Schedule schedule);
        //void DeleteSchedule(int id);

        //Schedule FindSchedule(int id);

        Schedule FindSchedule(int id);
        void AddSchedule(Schedule schedule);
        IList<Schedule> GetSchedule();
        void EditSchedule(Schedule schedule);
        void DeleteSchedule(int id);

        FlightCost FindFlightCost(int id);
        List<FlightCost> GetAllFlightClass();
        void AddFlightCost(FlightCost flightCost);
        void EditFlightCost(FlightCost flightCost);
        void DeleteFlightCost(int id);

        List<Flight> GetAllFlight();
        List<City> GetAllCity();
        List<Route> GetAllRoute();
        List<TravelClass> GetAllTravelClass();

        City FindCity(int id);
        
    }
}
