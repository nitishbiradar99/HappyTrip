using HappyTrip.Business;
using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyTrip.UI.MVC.Controllers
{
    public class ScheduleController : Controller
    {
        private ICityManager cityMgr = null;
        private IFlightManager flightMgr = null;
        private IAirlineManager airlineMgr = null;
        private IScheduleManager schMgr = null;
        private IRouteManager routeManager = null;
        private IFlightCostManager fcostMgr = null;
        public ScheduleController(ICityManager cityMgr, IFlightManager flightMgr, IAirlineManager airlineMgr, IScheduleManager schMgr, IRouteManager routeManager,IFlightCostManager fcostMgr)
        {
            this.airlineMgr = airlineMgr;
            this.cityMgr = cityMgr;
            this.schMgr = schMgr;
            this.flightMgr = flightMgr;
            this.routeManager = routeManager;
            this.fcostMgr = fcostMgr;
        }

        public ActionResult Index()
        {
            List<Schedule> schedules = schMgr.GetSchedule().ToList<Schedule>();
            foreach(var s in schedules )
            {
                 s.Route.FromCity = cityMgr.FindCity(s.Route.FromCityId);
                 s.Route.ToCity = cityMgr.FindCity(s.Route.ToCityId);
            }
            return View(schedules);
        }

        public ActionResult Create() {
            ViewBag.FromCity = new SelectList(cityMgr.GetCity(), "CityId", "CityName");
            ViewBag.ToCity = new SelectList(cityMgr.GetCity(), "CityId", "CityName");
            ViewBag.Flight = new SelectList(flightMgr.GetFlight(), " FlightID", "Name");
            ViewBag.Airline = new SelectList(airlineMgr.GetAirline(), "AirlineId", "AirlineName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ScheduleViewModel ScheduleView)
        {
            Schedule schedule = new Schedule(); 
            Route route = routeManager.GetRoute().FirstOrDefault(r => r.FromCityId == ScheduleView.FromCity && r.ToCityId == ScheduleView.ToCity);
            schedule.Route = route;
            schedule.RouteId = route.RouteID;
            Flight flight = flightMgr.GetFlight().FirstOrDefault(f => f.FlightID == ScheduleView.Flight);
            schedule.Flight = flight;
            schedule.FlightID = flight.FlightID;
            schedule.ArrivalTime = ScheduleView.ArrivalTime;
            schedule.DepartureTime = ScheduleView.DepartureTime;
            schedule.DurationInMins = ScheduleView.DurationInMins;
            FlightCost f1 = new FlightCost();
            f1.TravelClassId = 1;
            f1.Schedule = schedule;
            f1.CostPerTicket = ScheduleView.Business.CostPerTicket;
            fcostMgr.AddFlightCost(f1);
            FlightCost f2 = new FlightCost();
            f2.TravelClassId = 2;
            f2.CostPerTicket = ScheduleView.Business.CostPerTicket;
            f2.Schedule = schedule;
            fcostMgr.AddFlightCost(f2);
            //schMgr.AddSchedule(schedule);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id =0) 
        {
            Schedule sch = schMgr.FindSchedule(id);
            return View(sch);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id =0) 
        {
            schMgr.DeleteSchedule(id);
            return RedirectToAction("Index");
        }

        public ActionResult ScheduleAssign(SpecialSchedule sch) 
        {
            sch.RouteId = routeManager.GetRoute().FirstOrDefault(r => r.FromCityId == sch.FromCityId && r.ToCityId == sch.ToCityId).RouteID;
            Schedule newSchedule = new Schedule();
            newSchedule.ArrivalTime = sch.ArrivalTime;
            newSchedule.DepartureTime = sch.DepartureTime;
            newSchedule.DurationInMins = sch.DurationInMins;
            newSchedule.RouteId = sch.RouteId;
            newSchedule.FlightID = sch.FlightID;
            newSchedule.IsActive = sch.IsActive;
            schMgr.AddSchedule(newSchedule);
            return RedirectToAction("Index");
        }
    }
}