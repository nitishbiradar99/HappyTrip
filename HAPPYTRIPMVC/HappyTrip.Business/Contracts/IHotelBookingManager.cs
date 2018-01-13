using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Models;

namespace HappyTrip.Business.Contracts
{
    public interface IHotelBookingManager
    {
        void SaveBooking(HotelBooking booking);

        HotelBooking FindBookingByID(CancelBookingHotel cancelbooking);

        HotelBooking FindLastBookingDetails();

        void CancelBooking(int id);
    }
}
