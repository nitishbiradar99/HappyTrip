using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using HappyTrip.Models;

namespace HappyTrip.Business.Implementations
{
    public class HotelBookingManager : IHotelBookingManager
    {
        private IBookingHotelRepository bookingRepository = null;
        /// <summary>
        /// Constructor To Get HotelBooking Repository Object
        /// </summary>
        /// <param name="uow"></param>
        public HotelBookingManager(IUnitOfWork uow) 
        {
            bookingRepository = uow.GetHotelBookingRepository();
        }
        /// <summary>
        /// Method To Save The Hotel Booking
        /// </summary>
        /// <param name="booking"></param>
        public void SaveBooking(Models.HotelBooking booking)
        {
            bookingRepository.Create(booking);
        }
        /// <summary>
        /// Method To FindBooking By Booking ID
        /// </summary>
        /// <param name="cancelbooking"></param>
        /// <returns></returns>
        public Models.HotelBooking FindBookingByID(Models.CancelBookingHotel cancelbooking)
        {
            HotelBooking booking = bookingRepository.Find(cancelbooking.BookingIdNo);
            return booking;
        }

        /// <summary>
        /// Method To Get Last Booking Details.
        /// </summary>
        /// <returns></returns>
        public HotelBooking FindLastBookingDetails()
        {
            List<HotelBooking> hotelBooking = bookingRepository.All().ToList<HotelBooking>();
            return hotelBooking.Last();
        }
        /// <summary>
        /// Method To Cancel A Booking
        /// </summary>
        /// <param name="id"></param>
        public void CancelBooking(int id)
        {
            HotelBooking booking = bookingRepository.Find(id);
            booking.IsCanceled = true;
            bookingRepository.Update(booking);
        }
    }
}
