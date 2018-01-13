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
    public class HappyMilesController : Controller
    {
        private IBookingManager bookingMgr = null;
        public HappyMilesController(IBookingManager bookingMgr)
        {

            this.bookingMgr = bookingMgr;
        }
        public ActionResult HappyMile()
        {

            return View();

        }
        public ActionResult Index()
        {
            
            return View();
        }
        public PartialViewResult Search()
        {
            return PartialView("_Search");

        }
        [HttpPost]
        public ActionResult Search(FormCollection form)
        {

            string username = Request.Form["username"];
            List<Booking> bookings = bookingMgr.FindBookingByUser(username);
            return View("Index",bookings);

        }

        public PartialViewResult SearchByID()
        {
            return PartialView("_SearchBYID");

        }
        [HttpPost]
        public ActionResult SearchByID(FormCollection form)
        {
            string referenceNo = Request.Form["id"];
            List<Booking> bookings = bookingMgr.FindBookingByID(Convert.ToInt32(referenceNo));
            return View("Index", bookings);

        }
        
    }
}
