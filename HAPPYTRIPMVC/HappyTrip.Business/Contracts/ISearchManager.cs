using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Models;

namespace HappyTrip.Business.Contracts
{
    public interface ISearchManager
    {
        void SaveSearchInfo(SearchInfo info);

        SearchInfo GetSearchInfo();

        void SaveBookingDummy(HotelBooking booking);

        HotelBooking GetBooking();
    }
}
