using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using PagedList.Mvc;
using PagedList;
using System.IO;

namespace HappyTrip.UI.MVC.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        private IHotelManager hotelManager = null;
        private ICityManager cityManager = null;
        public HotelController(IHotelManager hotelmanager, ICityManager citymanager)
        {
            this.hotelManager = hotelmanager;
            this.cityManager = citymanager;
        }
        #region Hotel Crud
        /// <summary>
        /// Action To Show The Details Of Hotel
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            List<Hotel> hotels = hotelManager.GetHotels().ToList<Hotel>();
            return View(hotels.ToPagedList((page ?? 1), 8));
        }

        /// <summary>
        /// Action To Create Hotel
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateHotel()
        {
            var option = from n in cityManager.GetCity()
                         select new SelectListItem { Text = n.CityName, Value = n.CityId.ToString() };
            ViewBag.CityID = option;
            return View();
        }

        /// <summary>
        /// Action To Save the Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateHotel(Hotel hotel, HttpPostedFileBase file)
        {
            if (hotel.CityId != 0)
            {
                FileUpload(hotel, file);
                hotelManager.SaveHotel(hotel);
                return RedirectToAction("Index");
            }
            else
            {
                var option = from n in cityManager.GetCity().OrderBy(x=>x.CityName)
                             select new SelectListItem { Text = n.CityName, Value = n.CityId.ToString() };
                ViewBag.CityID = option;
                TempData["Error"] = "Please Fill All";
                return View();
            }
        }

        /// <summary>
        /// Action TO Delete The Hotel By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteHotel(int id)
        {
            hotelManager.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Action To Get Hotel Details To Upadte
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditHotel(int id)
        {
            return View(hotelManager.EditHotel(id));
        }
        
        /// <summary>
        /// Action To Update The Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditHotel(Hotel hotel, HttpPostedFileBase file)
        {
            if (Request.Files["file"] != null)
            {
                FileUpload(hotel, file);
            }
            hotelManager.Updatehotel(hotel);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method To Conver Img into Byte
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="file"></param>
        private void FileUpload(Hotel hotel, HttpPostedFileBase file)
        {
            if (Request.Files["file"] == null)
            {
                TempData["errorMessage"] = "Please Upload A FIle";
            }
            else if (Request.Files["file"].ContentLength > 0)
            {
                BinaryReader reader = new BinaryReader(file.InputStream);
                hotel.Photo = reader.ReadBytes(file.ContentLength);
            }
        }

        /// <summary>
        /// Method To Get Details Of Hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DetailsOfHotel(int id)
        {
            return View(hotelManager.EditHotel(id));
        } 
        #endregion
        #region Crud Of Hotel Room
        /// <summary>
        /// Method/Action To Display All HotelRooms
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetListOfHotelRooms(int? page)
        {
            List<HotelRoom> hotelRooms = hotelManager.GetHotelRoom().ToList<HotelRoom>();
            return View(hotelRooms.ToPagedList((page ?? 1), 8));
        }

        /// <summary>
        /// Method/Action For Create HotelRoom
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateHotelRoom()
        {
            DropDownList();
            return View();
        }

        /// <summary>
        /// Method To Create DropDownList
        /// </summary>
        private void DropDownList()
        {
            var optionroom = from n in hotelManager.GetRoomType()
                             select new SelectListItem { Text = n.Title, Value = n.TypeId.ToString() };
            ViewBag.TypeId = optionroom;

            var option = from n in hotelManager.GetHotels()
                         select new SelectListItem { Text = n.HotelName, Value = n.HotelId.ToString() };
            ViewBag.HotelId = option;
        }

        /// <summary>
        /// Method/Action To Save The Hotel Room
        /// </summary>
        /// <param name="hotelroom"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateHotelRoom(HotelRoom hotelroom, HttpPostedFileBase file)
        {
            if (Request.Files["file"] != null)
            {
                FileUpload(hotelroom, file);
            }
            hotelManager.SaveHotelRoom(hotelroom);
            return RedirectToAction("GetListOfHotelRooms");
        }

        /// <summary>
        /// Method/Action To Delete Hotel Room
        /// By Given HotelRoom Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteHotelRoom(int id)
        {
            hotelManager.Delete(id);
            return RedirectToAction("GetListOfHotelRooms");
        }

        /// <summary>
        /// Action To Get Hotel Room For Update
        /// By Given HotelRoom Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditHotelRoom(int id)
        {
            DropDownList();
            HotelRoom hotelroom = hotelManager.EditHotelRoom(id);
            return View(hotelroom);
        }

        /// <summary>
        /// Method/Action To Update The Hotel Room
        /// </summary>
        /// <param name="hotelroom"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditHotelRoom(HotelRoom hotelroom, HttpPostedFileBase file)
        {
            if (Request.Files["file"] != null)
            {
                FileUpload(hotelroom, file);
            }
            hotelManager.UpdateHotelRoom(hotelroom);
            return RedirectToAction("GetListOfHotelRooms");
        }

        /// <summary>
        /// Method/Action To Get And Display The
        /// Details Of HotelRoom 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DetailsHotelRoom(int id)
        {
            return View(hotelManager.EditHotelRoom(id));
        }

        /// <summary>
        /// Method To Convert Img Into Byte
        /// </summary>
        /// <param name="hotelroom"></param>
        /// <param name="file"></param>
        private void FileUpload(HotelRoom hotelroom, HttpPostedFileBase file)
        {
            if (Request.Files["file"] == null)
            {
                TempData["errorMessage"] = "Please Upload A FIle";
            }
            else if (Request.Files["file"].ContentLength > 0)
            {
                BinaryReader reader = new BinaryReader(file.InputStream);
                hotelroom.Photo = reader.ReadBytes(file.ContentLength);
            }
        }
        #endregion
        #region RoomType
        /// <summary>
        /// Action/Method To Display All RoomType
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetListOfRoomType(int? page)
        {
            List<RoomType> roomTypes = hotelManager.GetRoomType().ToList<RoomType>();
            return View(roomTypes.ToPagedList((page ?? 1), 8));
        }

        /// <summary>
        /// Action/Result To Create RoomType
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateRoomType()
        {
            return View();
        }

        /// <summary>
        /// Method/Action To Save Room Type
        /// </summary>
        /// <param name="roomtype"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateRoomType(RoomType roomtype)
        {
            hotelManager.SaveRoomType(roomtype);
            return RedirectToAction("GetListOfRoomType");
        }

        /// <summary>
        /// Method/Action To Delete Room Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteRoomType(int id)
        {
            hotelManager.Delete(id);
            return RedirectToAction("GetListOfRoomType");
        }

        /// <summary>
        /// Method/Action To Edit Room Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditRoomType(int id)
        {
            RoomType room = hotelManager.EditRoomType(id);
            return View(room);
        }

        /// <summary>
        /// Method/Action Update Room Type
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditRoomType(RoomType room)
        {
            hotelManager.UpdateRoomType(room);
            return RedirectToAction("GetListOfRoomType");
        }

        /// <summary>
        /// Action/Method To Display All Details
        /// By Given Room Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DetailsOfRoomType(int id)
        {
            return View(hotelManager.EditRoomType(id));
        }
        #endregion
    }
}