using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyTrip.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IScheduleManager scheduleMgr = null;
        private IStateManager stateMgr = null;
        private IBookingManager bookingMgr = null;
        private int count;

        public HomeController(IScheduleManager flightmanager, IStateManager stateManager, IBookingManager bookingManager)
        {
            this.stateMgr = stateManager;
            this.scheduleMgr = flightmanager;
            this.bookingMgr = bookingManager;
            this.count = Convert.ToInt32(ConfigurationManager.AppSettings["count"]);
        }

        /// <summary>
        /// Index Action for Flight Search
        /// Return a View of Flight Search Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var a = new SelectList(scheduleMgr.GetAllCity(), "CityId", "CityName");

            ViewBag.Name = new SelectList( scheduleMgr.GetAllFlight(), "FlightID", "Name");
            ViewBag.FromCityId = a;
            ViewBag.ToCityId = a;
            ViewBag.TravelClass = new SelectList(scheduleMgr.GetAllTravelClass(), "TravelClassId", "TravelClassName");

            #region Creating Drop Down for No of Ticket Allowed
            List<SelectListItem> noOfPeople = new List<SelectListItem>();
            for (int i = 0; i < count; i++)
            {
                noOfPeople.Add(new SelectListItem { Text = (i + 1).ToString(), Value = (i +1).ToString() });
            }

            ViewBag.NoOfPeople = new SelectList(noOfPeople, "Text", "Value");
            #endregion


            return View();
        }

        /// <summary>
        /// Flight Search Action of Home Controller
        /// Call by ajax request from Index page
        /// Return a Partial view with flights available for one way
        /// </summary>
        /// <param name="fromcity"></param>
        /// <param name="tocity"></param>
        /// <param name="fromDate"></param>
        /// <param name="noofPeople"></param>
        /// <param name="travelClass"></param>
        /// <returns></returns>
        public ActionResult FlightSearch(int fromcity, int tocity, string fromDate, int noofPeople, string travelClass)
        {
            Session["frmcity"] = fromcity;
            Session["tocity"] = tocity;
            Session["fromdate"] = fromDate;
            Session["noofpeople"] = noofPeople;
            Session["travelClass"] = travelClass;

            List<Schedule> schedules = scheduleMgr.GetSchedule().ToList<Schedule>();
            List<Schedule> sch = new List<Schedule>();
            if (fromcity != null && tocity != null && fromDate != null && noofPeople != null && travelClass != null)
            {

                foreach (var s in schedules)
                {
                    s.Route.FromCity = scheduleMgr.FindCity(s.Route.FromCityId);
                    s.Route.ToCity = scheduleMgr.FindCity(s.Route.ToCityId);
                }

                //Get Direct Schedules
                Route route = scheduleMgr.GetAllRoute().FirstOrDefault(p => p.FromCityId == fromcity && p.ToCityId == tocity);
                sch = scheduleMgr.GetSchedule().Where(p => p.RouteId == route.RouteID).ToList<Schedule>();

                //Get Connected Schedules
                List<Route> ConnectedToRoute = (scheduleMgr.GetAllRoute().Where(p => p.ToCityId == tocity)).ToList<Route>();
                List<Route> ConnectedFromRoute = (scheduleMgr.GetAllRoute().Where(p => p.FromCityId == fromcity)).ToList<Route>();

                List<Schedule> connectedSch = new List<Schedule>();
                List<Schedule> connectedToSch = new List<Schedule>();
                foreach (var item in ConnectedToRoute)
                {
                    foreach (var a in ConnectedFromRoute)
                    {
                        if (item.FromCityId == a.ToCityId)
                        {
                            connectedSch.AddRange(scheduleMgr.GetSchedule().Where(p => p.RouteId == a.RouteID).ToList<Schedule>());
                            connectedToSch.AddRange(scheduleMgr.GetSchedule().Where(p => p.RouteId == item.RouteID).ToList<Schedule>());
                        }
                    }
                }

                ViewBag.ConnectedSchedule = connectedSch;
                ViewBag.ConnectedToSch = connectedToSch;
                //return PartialView("SearchPartial", sch);
            }
            return PartialView("SearchPartial", sch);
        }

        /// <summary>
        /// Return Flight Search Action of Home Controller
        /// Call by ajax request from Index page
        /// Return a Partial view with flights available for return journey
        /// </summary>
        /// <param name="fromcity"></param>
        /// <param name="tocity"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="noofPeople"></param>
        /// <param name="travelClass"></param>
        /// <returns></returns>
        public ActionResult ReturnFlightSearch(int fromcity, int tocity, string fromDate, string toDate, int noofPeople, string travelClass)
        {
            Session["frmcity"] = fromcity;
            Session["tocity"] = tocity;
            Session["fromdate"] = fromDate;
            Session["todate"] = toDate;
            Session["noofpeople"] = noofPeople;
            Session["travelClass"] = travelClass;
            
            List<Schedule> schedules = scheduleMgr.GetSchedule().ToList<Schedule>();
            List<Schedule> sch = new List<Schedule>();
            if (fromcity != null && tocity != null && fromDate != null && toDate != null && noofPeople != null && travelClass != null)
            {
                foreach (var s in schedules)
                {
                    s.Route.FromCity = scheduleMgr.FindCity(s.Route.FromCityId);
                    s.Route.ToCity = scheduleMgr.FindCity(s.Route.ToCityId);
                }
                Route route = scheduleMgr.GetAllRoute().FirstOrDefault(p => p.FromCityId == fromcity && p.ToCityId == tocity);
                Route returnroute = scheduleMgr.GetAllRoute().FirstOrDefault(p => p.ToCityId == fromcity && p.FromCityId == tocity);
                sch = scheduleMgr.GetSchedule().Where(p => p.RouteId == route.RouteID).ToList<Schedule>();
                List<Schedule> returnSch = scheduleMgr.GetSchedule().Where(p => p.RouteId == returnroute.RouteID).ToList<Schedule>();
                ViewBag.ReturnSchedule = returnSch;
            }
            return PartialView("SearchReturnPartial", sch);
        }

        /// <summary>
        /// Book Flight For Home Controller
        /// Stores information from the parial view call by index page
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public ActionResult BookFlight(FormCollection collection)
        {
            Session["flightId"] = collection["flightId"].ToString();
           // scheduleMgr.GetSchedule().FirstOrDefault(x => x.FlightID ==Convert.ToInt32(collection["FlightId"].ToString())).flightCosts;

            ViewBag.StateId = new SelectList(stateMgr.GetState(), "StateId", "StateName");
            return View();
        }

        /// <summary>
        /// Action for adding contact for the booking
        /// and creates a booking 
        /// </summary>
        /// <param name="bookingContact"></param>
        /// <returns></returns>
        public ActionResult AddBookingContact(BookingContact bookingContact)
        {
            int id = Convert.ToInt32(Session["flightId"].ToString());
            var travelClass = (Session["travelClass"].ToString());
            decimal cost = 0;
            foreach (var item in scheduleMgr.GetSchedule())
            {
                foreach (var a in item.flightCosts)
                {
                    if (item.FlightID == id && a.TravelClass.TravelClassId == Convert.ToInt32(Session["travelClass"].ToString()))
                    {
                        cost = a.CostPerTicket;
                    }
                }
            }

            Session["guid"] = (cost.GetHashCode()).ToString();
            string S1 = Session["guid"].ToString();

            Booking B = new Booking();
            B.BookingDate = DateTime.Now;
            B.IsCanceled = false;
            B.TotalCost = cost;
            B.UserName = "User Name";
            //B.BookingNo = S1;
            B.BookingContact = bookingContact;
            bookingMgr.AddBooking(B);

            #region Email Service to Contact
            //string body = B.BookingDate.ToString() + B.TotalCost.ToString() + Session["fromdate"].ToString() + Session["tocity"].ToString() + "No of Passengers : " + Session["noofpeople"].ToString();
            //string emailId = bookingContact.Email;

            //EmailWCFService.SMTPMailSetup emailsetup = new EmailWCFService.SMTPMailSetup();

            //emailsetup.SendMail(emailId, "Happy Trip Ticket", body);
            #endregion

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Adds passesnger method of Home Controller
        /// Call by ajax post from Booking page
        /// </summary>
        /// <param name="modelData"></param>
        /// <returns></returns>
        public ActionResult AddPassenger(Passenger modelData)
        {
            bookingMgr.AddPassenger(modelData);
            return RedirectToAction("BookFlight");
        }

        /// <summary>
        /// About Action of Home Controller
        /// Show information of the company
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        /// <summary>
        /// Contact Action of Home Controller 
        /// Return view for Contact page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
