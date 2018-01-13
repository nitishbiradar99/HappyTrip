using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Models;

namespace HappyTrip.Data.EFRepository
{
    internal class HappyTripDBCon : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<FlightClass> FlightClasses { get; set; }
        public DbSet<FlightCost> FlightCost { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<BookingContact> BookingContacts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<HotelBookingContact> HotelBookingContacts { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<SearchInfo> SearchInfos { get; set; }
        public DbSet<User> UserProfile { get; set; }
        public DbSet<SpecialSchedule> SpecialSchedules { get; set; }
    }
}
