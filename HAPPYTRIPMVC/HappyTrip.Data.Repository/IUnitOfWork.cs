using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Data.Repository
{
    public interface IUnitOfWork
    {
        IRouteRepo GetRouteRepository();
        IStateRepo GetStateRepository();
        ICityRepo GetCityRepository();
        ITravelClassRepo GetTravelClassRepository();
        IAirlineRepo GetAirlineRepository();
        IFlightRepo GetFlightRepository();
        IFlightClassRepo GetFlightClassRepository();
        //IScheduleRepo GetScheduleRepository();
        //IFlightCostRepo GetFlightCostRepository();
        IBookingRepo GetBookingRepository();
        IBookingContactRepo GetBookingContactRepository();
        IPassengerRepo GetPassengerRepository();
        ITicketRepository GetTicketRepository();
        IRoomTypeRepository GetRoomTypeRepository();
        IHotelRoomRepository GetHotelRoomRepository();
        IHotelRepository GetHotelRepository();
        IBookingHotelRepository GetHotelBookingRepository();
        IUserAcountRepository GetUserAcountRepository();

        IScheduleRepositry GetScheduleRepositry();

        ISpecialScheduleRepo GetSpecialScheduleRepositry();

        IFlightCostRepository GetFlightCostRepository();
    }
}
