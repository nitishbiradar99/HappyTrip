using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace HappyTrip.UI.MVC.Controllers
{
    public class FlightController : Controller
    {
        private IFlightManager flightMgr = null;

        public FlightController(IFlightManager flightmanager)
        {
            this.flightMgr = flightmanager;
        }

        /// <summary>
        /// Index Action of Flight Controller
        /// Return a list of Flight View
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            ViewBag.TravelClass = flightMgr.GetAllTravelClass();
            ViewBag.FlightClass = flightMgr.GetFlightClass();

            List<Flight> flights = flightMgr.GetFlight().ToList<Flight>();

            return View(flights.ToPagedList((page?? 1), 8));
        }

        /// <summary>
        /// Get Request of Create Action
        /// Returns a create view for Flight
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.AirlineId = new SelectList(flightMgr.GetAllAirline(), "AirlineId", "AirlineName");
            ViewBag.TravelClass = flightMgr.GetAllTravelClass();
            return View();
        }

        /// <summary>
        /// Post Request of Create Action
        /// Returns Index view for Flight if successed
        /// Returns a create view for Flight if fails
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Flight flight)
        {
            FlightClass fc = new FlightClass();
            fc.NoOfSeats =Convert.ToInt32(Request["1"]);
            fc.TravelClassId = 1;
            fc.Flight = flight;
            flightMgr.AddFlightClass(fc);

            FlightClass fc1 = new FlightClass();
            fc1.NoOfSeats = Convert.ToInt32(Request["2"]);
            fc1.TravelClassId = 2;
            fc1.Flight = flight;

            flightMgr.AddFlightClass(fc1);

            //flight.classes.Add(fc);
            //flight.classes.Add(fc1);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Get Request of Edit Action
        /// Returns a edit view for Flight for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Flight flight = flightMgr.FindFlight(id);

            ViewBag.AirlineId = new SelectList(flightMgr.GetAllAirline(), "AirlineId", "AirlineName", flight.AirlineId);
            ViewBag.TravelClass = flightMgr.GetAllTravelClass();
            ViewBag.FlightClass = flightMgr.GetFlightClass();

            return View(flight);
        }

        /// <summary>
        /// Post Request of Edit Action
        /// Returns index view for Flight for a given id if successed
        /// Returns a edit view for Flight for a given id if fails
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Flight flight)
        {
            if(ModelState.IsValid)
            {
                flightMgr.EditFlight(flight);

                int id = Convert.ToInt32(Request["Business"].ToString());
                FlightClass flightclass = flightMgr.FindFlightClass(id);
                flightclass.NoOfSeats = Convert.ToInt32(Request["2"].ToString());
                flightMgr.EditFlightClass(flightclass);

                int id1 = Convert.ToInt32(Request["Economy"].ToString());
                FlightClass flightclass1 = flightMgr.FindFlightClass(id);
                flightclass.NoOfSeats = Convert.ToInt32(Request["1"].ToString());
                flightMgr.EditFlightClass(flightclass1);

                TempData["Message"] = "Flight Details Edited sucessfully...";
                return RedirectToAction("Index");
            }
            ViewBag.AirlineId = new SelectList(flightMgr.GetAllAirline(), "AirlineId", "AirlineName", flight.AirlineId);
            ViewBag.TravelClass = flightMgr.GetAllTravelClass();
            ViewBag.FlightClass = flightMgr.GetFlightClass();

            ViewBag.Message = "Something went wrong try again....";
            return View(flight);
        }

        /// <summary>
        /// Get Request of Delete Action
        /// Return a Delete view for a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public ActionResult Delete(int id)
        //{
        //    Flight flightClass = flightMgr.FindFlight(id);
        //    ViewBag.TravelClass = flightMgr.GetAllTravelClass();
        //    ViewBag.FlightClass = flightMgr.GetFlightClass();
        //    ViewBag.AirlineId = new SelectList(flightMgr.GetAllAirline(), "AirlineId", "AirlineName", flightClass.AirlineId);

        //    return View(flightClass);
        //}

        /// <summary>
        /// Post Request of Delete Action
        /// Return index view for a given Id if successed
        /// Return a Delete view for a given Id if fails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    flightMgr.DeleteFlight(id);

        //    return RedirectToAction("Index");
        //}

    }
}
