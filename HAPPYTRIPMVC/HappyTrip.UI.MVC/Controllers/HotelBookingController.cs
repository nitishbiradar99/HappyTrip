using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyTrip.Business.Contracts;
using HappyTrip.Business.Implementations;
using HappyTrip.Models;

namespace HappyTrip.UI.MVC.Controllers
{
    public class HotelBookingController : Controller
    {
        //
        // GET: /HotelBooking/
        private IHotelBookingManager hotelbookingManager = null;
        private IHotelManager hotelManager = null;
        private ICityManager cityManager = null;
        private ISearchManager searchManager = null;
        public HotelBookingController(ICityManager cityManager, IHotelBookingManager hotelbookingManager, IHotelManager hotelManager)
        {
            this.hotelManager = hotelManager;
            this.cityManager = cityManager;
            this.hotelbookingManager = hotelbookingManager;
        }

        /// <summary>
        /// Index To Search Hotel
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                var option = from n in cityManager.GetCity().OrderBy(x=>x.CityName)
                             select new SelectListItem { Text = n.CityName, Value = n.CityId.ToString() };
                ViewBag.CityId = option;
                //ViewBag.CityId = cityManager.GetCity();
                List<int> noofperson = null;
                noofperson = new List<int> { 1, 2, 3, 4, 5, 6 };
                var person = from m in noofperson
                             select new SelectListItem { Text = m.ToString(), Value = m.ToString() };
                ViewBag.NoOfPeople = person; 
                List<int> noofroom = null;
                noofroom = new List<int> { 1, 2, 3, 4, 5, 6 };
                var room = from p in noofroom
                           select new SelectListItem { Text = p.ToString(), Value = p.ToString() };
                ViewBag.NoOfRooms = room;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        /// <summary>
        /// Action To Show The Search Result
        /// By Given City ID
        /// </summary>
        /// <param name="info"></param>
        /// <param name="CityId"></param>
        /// <returns></returns>
        public ActionResult SearchResult(SearchInfo info, int CityId = 0)
        {
            try
            {
                if (CityId != 0)
                {
                    CreateSession();
                    DateTime ciDate = (DateTime)info.CheckInDate;
                    DateTime coDate = (DateTime)info.CheckOutDate;
                    if (coDate >= ciDate)
                    {
                        TimeSpan span = coDate - ciDate;
                        info.NoOfNight = span.Days + 1;
                        searchManager.SaveSearchInfo(info);
                        if (hotelManager.Search(CityId).Count > 0)
                        {
                            return View(hotelManager.Search(CityId));  
                        }
                        else
                        {
                            TempData["DateerrorMessage"] = "No Hotel Found On Particular City";
                        }
                    }
                    else
                    {
                        TempData["DateerrorMessage"] = "Check Out Date Should Be <= To Check In Date";
                    }
                }
                else
                {
                    TempData["DateerrorMessage"] = "Please Select all field";
                    return RedirectToAction("Index", "HotelBooking");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index", "HotelBooking");           
        }

        /// <summary>
        /// Method To Create Session
        /// </summary>
        private void CreateSession()
        {
            if (Session["searchManager"] == null)
            {
                searchManager = new SearchManager();
                Session["searchManager"] = searchManager;
            }
            else
            {
                searchManager = (SearchManager)Session["searchManager"];
            }
        }

        /// <summary>
        /// Action To Show Search Details 
        /// By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SearchDetails(int id)
        {
            try
            {
                CreateSession();
                SearchInfo info = searchManager.GetSearchInfo();
                info.HotelId = id;
                info.Hotels = new Hotel();
                info.Hotels = hotelManager.FindHotel(id);
                ViewBag.SearchInfo = info;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(hotelManager.SearchHotelById(id));            
        }

        /// <summary>
        /// Action To display All Avalable Room 
        /// By Given Hotel Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Booking(int id)
        {
            try
            {
                CreateSession();
                SearchInfo info = searchManager.GetSearchInfo();
                decimal billAmount = (decimal)hotelManager.GetTotalBill(info, id);
                TempData["TotalCost"] = billAmount;
                ViewBag.SearchInfo = info;
                ViewBag.TotalCost = billAmount;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(hotelManager.EditHotelRoom(id));
        }

        /// <summary>
        /// Action To Enter Persional Details For 
        /// Guest User
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterDetails()
        {
            return PartialView("_EnterDetails");
        }

        /// <summary>
        /// Action To Proceed Payment
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BookedDetails(HotelBooking booking)
        {
            try
            {
                CreateSession();
                SearchInfo info = searchManager.GetSearchInfo();
                booking.BookingDate = DateTime.Now;
                booking.TotalCost = (decimal)TempData["TotalCost"];
                booking.HotelBookingContacts = new HotelBookingContact()
                {
                ContactName = booking.HotelBookingContacts.ContactName,
                EmailID = booking.HotelBookingContacts.EmailID,
                PhoneNo = booking.HotelBookingContacts.PhoneNo
                };

                booking.SearchInfos = new SearchInfo()
                {
                CheckInDate = info.CheckInDate,
                CheckOutDate = info.CheckOutDate,
                NoOfNight = info.NoOfNight,
                NoOfPeople = info.NoOfPeople,
                NoOfRooms = info.NoOfRooms,
                HotelId = info.HotelId,
                ExtraCost = info.ExtraCost
                };
                searchManager.SaveBookingDummy(booking);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }
            return RedirectToAction("CreatePayment","Payment");
        }

        /// <summary>
        /// Action/Method To Store Booking Details
        /// </summary>
        /// <returns></returns>
        public ActionResult Get() 
        {
            HotelBooking HBooking = null;
            try
            {
                CreateSession();
                HotelBooking ho = searchManager.GetBooking();
                hotelbookingManager.SaveBooking(ho);
                HBooking = hotelbookingManager.FindLastBookingDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(HBooking);
        }

        /// <summary>
        /// Method To Cancelation Of Ticket
        /// </summary>
        /// <returns></returns>
        public ActionResult CancelBooking()
        {
            return View();
        }

        /// <summary>
        /// Action Conformation And Diaplaying Details 
        /// </summary>
        /// <param name="cancelbooking"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CancelBookingDetails(CancelBookingHotel cancelbooking)
        {
            HotelBooking booking = hotelbookingManager.FindBookingByID(cancelbooking);
            if (booking.HotelBookingContacts.EmailID == cancelbooking.EmailId)
            {
                return View(booking);
            }
            else
            {
                TempData["errorMsg"] = "Email-ID or Booking Id Not Match";
                return RedirectToAction("CancelBooking");
            }
        }

        /// <summary>
        /// Action To Cancel The Booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ConfirmCancel(int id)
        {
            hotelbookingManager.CancelBooking(id);
            return RedirectToAction("Index");
        }
    }
}