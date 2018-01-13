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
   internal class ScheduleManager:IScheduleManager
    {
       //private IScheduleRepositry repo = null;
       

       //public ScheduleManager(IUnitOfWork uof)
       //{
       //    this.repo = uof.GetScheduleRepositry();
           
       //}

       // public void AddSchedule(Models.Schedule schedule)
       // {
       //     repo.Create(schedule);
       // }

       // public IList<Models.Schedule> GetSchedule()
       // {
       //    return repo.All().ToList<Schedule>();
       // }

       // public void EditSchedule(Models.Schedule schedule)
       // {
       //     repo.Update(schedule);
       // }

       // public void DeleteSchedule(int id)
       // {
       //     repo.Delete(id);
       // }

       // public Models.Schedule FindSchedule(int id)
       // {
       //   return  repo.Find(id);
       // }
        private IScheduleRepositry scheduleRepo = null;
        private IFlightCostRepository FlightCostRepo = null;
        private IFlightRepo FlightRepo = null;
        private ICityRepo CityRepo = null;
        private IRouteRepo RouteRepo = null;
        private ITravelClassRepo TravelClassRepo = null;

        public ScheduleManager(IUnitOfWork uow)
        {
            this.scheduleRepo = uow.GetScheduleRepositry();
            this.FlightCostRepo = uow.GetFlightCostRepository();
            this.FlightRepo = uow.GetFlightRepository();
            this.CityRepo = uow.GetCityRepository();
            this.RouteRepo = uow.GetRouteRepository();
            this.TravelClassRepo = uow.GetTravelClassRepository();
        }

        public Models.Schedule FindSchedule(int id)
        {
            Models.Schedule schedule = scheduleRepo.Find(id);
            return schedule;
        }

        public void AddSchedule(Models.Schedule schedule)
        {
            //scheduleRepo.AddSchedule(schedule);
            scheduleRepo.Create(schedule);
        }

        public IList<Models.Schedule> GetSchedule()
        {
            return scheduleRepo.All().ToList<Models.Schedule>();
        }

        public void EditSchedule(Models.Schedule schedule)
        {
            scheduleRepo.Update(schedule);
        }

        public void DeleteSchedule(int id)
        {
            scheduleRepo.Delete(id);
        }

        public Models.FlightCost FindFlightCost(int id)
        {
            Models.FlightCost flightCost = FlightCostRepo.Find(id);
            return flightCost;
        }

        public List<Models.FlightCost> GetAllFlightClass()
        {
            return FlightCostRepo.All().ToList<Models.FlightCost>();
        }

        public void AddFlightCost(Models.FlightCost flightCost)
        {
            FlightCostRepo.Create(flightCost);
            //scheduleRepo.AddFlightCost(flightCost);
        }

        public void EditFlightCost(Models.FlightCost flightCost)
        {
            FlightCostRepo.Update(flightCost);
        }

        public void DeleteFlightCost(int id)
        {
            FlightCostRepo.Delete(id);
        }


        public List<Models.Flight> GetAllFlight()
        {
            return FlightRepo.All().ToList<Flight>();
        }


        public List<City> GetAllCity()
        {
            return CityRepo.All().ToList<City>();
        }


        public List<Route> GetAllRoute()
        {
            return RouteRepo.All().ToList<Route>();
        }


        public List<TravelClass> GetAllTravelClass()
        {
            return TravelClassRepo.All().ToList<TravelClass>();
        }


        public City FindCity(int id)
        {
            City city = CityRepo.Find(id);
            return city;
        }


    }
}
