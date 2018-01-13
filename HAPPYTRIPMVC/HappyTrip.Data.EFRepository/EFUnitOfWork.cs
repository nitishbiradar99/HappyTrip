using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Data.Repository;

namespace HappyTrip.Data.EFRepository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IRouteRepo repo;
        private IStateRepo srepo;
        private ICityRepo crepo;
        private ITravelClassRepo tcrepo;
        private IAirlineRepo airlinerepo;
        private IFlightRepo flightrepo;
        private IFlightClassRepo flightClassrepo;
        //private IScheduleRepo schedulerepo;
        //private IFlightCostRepo flightCostrepo;
        private IBookingContactRepo bookingContactRepo;
        private IBookingRepo bookingRepo;
        private IPassengerRepo passengerRepo;

        public IRouteRepo GetRouteRepository()
        {
            repo = new RouteEFRepository();
            return repo;
        }

        public IStateRepo GetStateRepository()
        {
            srepo = new StateEFRepository();
            return srepo;
        }

        public ICityRepo GetCityRepository()
        {
            crepo = new CityEFRepository();
            return crepo;
        }

        public ITravelClassRepo GetTravelClassRepository()
        {
            tcrepo = new TravelClassEFRepository();
            return tcrepo;
        }

        public IAirlineRepo GetAirlineRepository()
        {
            airlinerepo = new AirlineEFRepository();
            return airlinerepo;
        }

        public IFlightRepo GetFlightRepository()
        {
            flightrepo = new FlightEFRepository();
            return flightrepo;
        }

        public IFlightClassRepo GetFlightClassRepository()
        {
            flightClassrepo = new FlightClassEFRepository();
            return flightClassrepo;
        }

        //public IScheduleRepositry GetScheduleRepository()
        //{
        //    schedulerepo = new ScheduleEFRepository();
        //    return schedulerepo;
        //}


        //public IFlightCostRepo GetFlightCostRepository()
        //{
        //    flightCostrepo = new FlightCostEFRepository();
        //    return flightCostrepo;
        //}

        public IBookingRepo GetBookingRepository()
        {
            bookingRepo = new BookingEFRepository();
            return bookingRepo;
        }

        public IBookingContactRepo GetBookingContactRepository()
        {
            bookingContactRepo = new BookingContactEFRepository();
            return bookingContactRepo;
        }

        public IPassengerRepo GetPassengerRepository()
        {
            passengerRepo = new PassengerEFRepository();
            return passengerRepo;
        }

        public ITicketRepository GetTicketRepository()
        {
            return new TicketEFRepository();
        }

        /// <summary>
        /// Method To Get RoomType Ef Instance
        /// </summary>
        /// <returns></returns>
        public IRoomTypeRepository GetRoomTypeRepository()
        {
            return new RoomTypeEFRepository();
        }
        /// <summary>
        /// Method To Get Hotel Room EF Instance
        /// </summary>
        /// <returns></returns>
        public IHotelRoomRepository GetHotelRoomRepository()
        {
            return new HotelRoomEFRepository();
        }
        /// <summary>
        /// Method To Get Hotel Ef Instance
        /// </summary>
        /// <returns></returns>
        public IHotelRepository GetHotelRepository()
        {
            return new HotelEFRepository();
        }
        /// <summary>
        /// Method To Get Hotel Booking Ef Instance
        /// </summary>
        /// <returns></returns>
        public IBookingHotelRepository GetHotelBookingRepository()
        {
            return new BookingHotelEFRepository();
        }
        /// <summary>
        /// Method TO Get UserAcount Repository
        /// </summary>
        /// <returns></returns>
        public IUserAcountRepository GetUserAcountRepository()
        {
            return new UserAcountEFRepository();
        }

        public IScheduleRepositry GetScheduleRepositry()
        {
            return new ScheduleEFRepositry();
        }

        public ISpecialScheduleRepo GetSpecialScheduleRepositry()
        {
            return new SpecialScheduleRepositry();
        }

        public IFlightCostRepository GetFlightCostRepository()
        {
            return new FlightCostEFRepository();
        }

    }
}
