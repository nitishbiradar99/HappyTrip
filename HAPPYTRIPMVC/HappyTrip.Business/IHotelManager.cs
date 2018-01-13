using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Models;

namespace HappyTrip.Business.Contracts
{
    public interface IHotelManager
    {
        #region Method Of Hotel
        void SaveHotel(HappyTrip.Models.Hotel hotel);

        IList<HappyTrip.Models.Hotel> GetHotels();

        void Delete(int id);

        HappyTrip.Models.Hotel EditHotel(int id);

        void Updatehotel(HappyTrip.Models.Hotel hotel);

        HappyTrip.Models.Hotel FindHotel(int id);
        #endregion
        #region Methods Of Hotel Rooms
        void SaveHotelRoom(HotelRoom hotelroom);

        IList<HotelRoom> GetHotelRoom();

        void DeleteHotelRoom(int id);

        HotelRoom EditHotelRoom(int id);

        void UpdateHotelRoom(HotelRoom hotelroom);

        List<HotelRoom> Search(int cityid);

        List<HotelRoom> SearchHotelById(int id);
        
        double GetTotalBill(SearchInfo info, int id);

        #endregion
        #region Methods Of Room Type
        void SaveRoomType(RoomType roomtype);

        IList<RoomType> GetRoomType();

        void DeleteRoomType(int id);

        RoomType EditRoomType(int id);

        void UpdateRoomType(RoomType roomtype);
        #endregion
    }
}
