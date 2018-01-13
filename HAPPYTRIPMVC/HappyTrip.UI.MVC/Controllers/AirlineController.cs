using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace HappyTrip.UI.MVC.Controllers
{
    public class AirlineController : Controller
    {
        private IAirlineManager airlineMgr = null;

        public AirlineController(IAirlineManager am)
        {
            this.airlineMgr = am;
        }

        /// <summary>
        /// Returns a View for List of Airlines
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            List<Airline> airlineList = airlineMgr.GetAirline().ToList<Airline>();
            return View(airlineList.ToPagedList((page ?? 1), 8));
        }

        /// <summary>
        /// Get Request of Create Action of Airline
        /// Returns a Create View for Airline
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Request of Create Action of Airline
        /// Returns Index View for Airline if successed
        /// Returns a Create View for Airline if fails
        /// </summary>
        /// <param name="airline"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Airline airline, HttpPostedFileBase file)
        {
            airline.Logo = "Content/images/AirlineLogo/noimg.jpg";
            if (airline.AirlineName != null && airline.Code != null)
            {
                airlineMgr.AddAirline(airline, file);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Airline Name or Airline Code filed left blank");
                return View();
            }
            
        }

        /// <summary>
        /// Get Request of Edit Action of Airline
        /// Return a view for Airline for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Airline a = airlineMgr.FindAirline(id);
            return View(a);
        }

        /// <summary>
        /// Post Request of Edit Action of Airline
        /// Return a view for Airline for a given id if fails
        /// Returns Index view if Successed
        /// </summary>
        /// <param name="airline"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Airline airline, HttpPostedFileBase file)
        {
            //airline.Logo = "zzz";
            if (file != null)
            {
                if (airline.AirlineName != null || file.ContentLength > 0)
                {
                    airlineMgr.EditAirline(airline, file);
                    ViewBag.Message = "Airline Edited Sucessfully";
                    return RedirectToAction("Index");
                }
            }
            else 
            {
                airlineMgr.EditAirline(airline);
                ViewBag.Message = "Airline Edited Sucessfully";
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Something went wrong try again....";
            return View(airline);
        }
    }
}
