using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface IBookingManager 
    {
        IList<Booking> GetBooking();
        void AddBooking(Booking booking);
        Booking FindBooking(int id);
        List<Booking> FindBookingByUser(string username);
        void EditBooking(Booking booking);
        void DeleteBooking(int id);
        void AddPassenger(Passenger p);
        void AddContactDetails(BookingContact bookingcontact);
        List<Booking> FindBookingByID(int id);
    }
}
