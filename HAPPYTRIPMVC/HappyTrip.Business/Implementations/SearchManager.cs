using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Business.Contracts;
using HappyTrip.Models;

namespace HappyTrip.Business.Implementations
{
    public class SearchManager : ISearchManager
    {
        private SearchInfo SearchInfos = new SearchInfo();
        /// <summary>
        /// Method To Save Search Information
        /// </summary>
        /// <param name="info"></param>
        public void SaveSearchInfo(Models.SearchInfo info)
        {
            SearchInfos = info;
        }
        /// <summary>
        /// Method To Get SearchInfo
        /// </summary>
        /// <returns></returns>
        public Models.SearchInfo GetSearchInfo()
        {
            return SearchInfos;
        }
        private HotelBooking hotelbooking = new HotelBooking();


        public void SaveBookingDummy(HotelBooking booking)
        {
            hotelbooking = booking;
        }

        public HotelBooking GetBooking()
        {
            return hotelbooking;
        }
    }
}
