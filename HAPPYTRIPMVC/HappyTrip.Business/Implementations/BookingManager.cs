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
    internal class BookingManager : IBookingManager
    {
        IBookingRepo bookingRepo = null;
        IPassengerRepo passengerRepo = null;
        IBookingContactRepo bookingContactRepo = null;

        public BookingManager(IUnitOfWork uow)
        {
            this.bookingRepo = uow.GetBookingRepository();
            this.passengerRepo = uow.GetPassengerRepository();
            this.bookingContactRepo = uow.GetBookingContactRepository();
        }

        public IList<Models.Booking> GetBooking()
        {
            return bookingRepo.All().ToList<Models.Booking>();
        }

        public void AddBooking(Models.Booking booking)
        {
            bookingRepo.Create(booking);
        }

        public Models.Booking FindBooking(int id)
        {
            Models.Booking booking = bookingRepo.Find(id);
            return booking;
        }

        public void EditBooking(Models.Booking booking)
        {
            bookingRepo.Update(booking);
        }

        public void DeleteBooking(int id)
        {
            bookingRepo.Delete(id);
        }

        public void AddPassenger(Models.Passenger p)
        {
            passengerRepo.Create(p);
        }

        public void AddContactDetails(Models.BookingContact bookingcontact)
        {
            bookingContactRepo.Create(bookingcontact);
        }


        public List<Models.Booking> FindBookingByUser(string username)
        {
            List<Booking> bookings = bookingRepo.All().ToList<Booking>();
            bookings = (from booking in bookings
                        where booking.UserName.ToLower().Contains(username.ToLower())
                        select booking).ToList<Booking>();
            return bookings;

        }


        public List<Booking> FindBookingByID(int id)
        {
            List<Booking> bookings = bookingRepo.All().ToList<Booking>();
            bookings = (from booking in bookings
                        where (booking.BookingNo.Equals(id))
                        select booking).ToList<Booking>();
            return bookings;
        }
    }
}
