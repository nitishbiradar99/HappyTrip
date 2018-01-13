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
    public class SpecialScheduleController : Controller
    {
        private ICityManager cityMgr = null;
        private IFlightManager flightMgr = null;
        private IAirlineManager airlineMgr = null;
        private IScheduleManager schMgr = null;
        private IRouteManager routeManager = null;
        private IFlightCostManager fcostMgr = null;
        private ISpecialScheduleManager specialMgr = null;

        public SpecialScheduleController(ICityManager cityMgr, IFlightManager flightMgr, IAirlineManager airlineMgr, IScheduleManager schMgr, IRouteManager routeManager, IFlightCostManager fcostMgr, ISpecialScheduleManager specialMgr)
        {
            this.airlineMgr = airlineMgr;
            this.cityMgr = cityMgr;
            this.schMgr = schMgr;
            this.flightMgr = flightMgr;
            this.routeManager = routeManager;
            this.fcostMgr = fcostMgr;
            this.specialMgr = specialMgr;
           
        }
        public ActionResult Index()
        {
            List<SpecialSchedule> schedules = specialMgr.GetSchedule().ToList<SpecialSchedule>();



            return View(schedules);
        }

        //
        // GET: /SpecialSchedule/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SpecialSchedule/Create

        public ActionResult Create()
        {
            ViewBag.FromCityId = new SelectList(cityMgr.GetCity(), "CityId", "CityName");
            ViewBag.ToCityId = new SelectList(cityMgr.GetCity(), "CityId", "CityName");
            ViewBag.FlightId = new SelectList(flightMgr.GetFlight(), " FlightID", "Name");
            ViewBag.Airline = new SelectList(airlineMgr.GetAirline(), "AirlineId", "AirlineName");

            return View();
        }

        //
        // POST: /SpecialSchedule/Create

        [HttpPost]
        public ActionResult Create(SpecialSchedule sch)
        {
          
    

            specialMgr.AddSchedule(sch);

            return RedirectToAction("ScheduleAssign","Schedule",sch);
        }

        //
        // GET: /SpecialSchedule/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SpecialSchedule/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SpecialSchedule/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SpecialSchedule/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
