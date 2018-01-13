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
    public class HotelManager : IHotelManager
    {
        private IHotelRepository hotelRepository = null;
        private IHotelRoomRepository hotelroomRepository = null;
        private IRoomTypeRepository roomtypeRepository = null;

        public HotelManager(IUnitOfWork uow)
        {
            this.hotelRepository = uow.GetHotelRepository();
            this.hotelroomRepository = uow.GetHotelRoomRepository();
            this.roomtypeRepository = uow.GetRoomTypeRepository();
        }
        #region Crud Hotel
        /// <summary>
        /// Method To Add/Save Hotel In Repository
        /// </summary>
        /// <param name="hotel"></param>
        public void SaveHotel(HappyTrip.Models.Hotel hotel)
        {
            hotelRepository.Create(hotel);
        }
        /// <summary>
        /// Method To Get List Of Hotel
        /// </summary>
        /// <returns></returns>
        public IList<HappyTrip.Models.Hotel> GetHotels()
        {
            return hotelRepository.All().ToList<HappyTrip.Models.Hotel>();
        }
        /// <summary>
        /// Method To Delete Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            hotelRepository.Delete(id);
        }
        /// <summary>
        /// Method To Return Hotel Object by Given Id For Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HappyTrip.Models.Hotel EditHotel(int id)
        {
            return hotelRepository.Find(id);
        }
        /// <summary>
        /// Method To Update
        /// </summary>
        /// <param name="hotel"></param>
        public void Updatehotel(HappyTrip.Models.Hotel hotel)
        {
            hotelRepository.Update(hotel);
        }
        /// <summary>
        /// Method To GetHotel Details By Given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HappyTrip.Models.Hotel FindHotel(int id)
        {
            return hotelRepository.Find(id);
        }
        #endregion
        /// <summary>
        /// Method To Add/Save HotelRoom In HotelRoomEFRepository
        /// </summary>
        /// <param name="hotelroom"></param>
        public void SaveHotelRoom(HotelRoom hotelroom)
        {
            hotelroomRepository.Create(hotelroom);
        }
        /// <summary>
        /// Method To Get List Of HotelRoom
        /// </summary>
        /// <returns></returns>
        public IList<HotelRoom> GetHotelRoom()
        {
            return hotelroomRepository.All().ToList<HotelRoom>();
        }
        /// <summary>
        /// Method To Delete HotelRoom By Given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteHotelRoom(int id)
        {
            hotelroomRepository.Delete(id);
        }
        /// <summary>
        /// Method To Return The Object Of HotelRoom By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelRoom EditHotelRoom(int id)
        {
            return hotelroomRepository.Find(id);
        }
        /// <summary>
        /// Method To Update The HotelRoom
        /// </summary>
        /// <param name="hotelroom"></param>
        public void UpdateHotelRoom(HotelRoom hotelroom)
        {
            hotelroomRepository.Update(hotelroom);
        }
        /// <summary>
        /// Search Hotel By CityId
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public List<HotelRoom> Search(int cityid)
        {
            var hotel = GetHotelDetails();

            var hotelcity = from n in hotel
                            where n.Hotel.City.CityId == cityid
                            select n;
            var hoteldistint = hotelcity.GroupBy(p => p.HotelId).Select(x => x.First());
            return hoteldistint.ToList<HotelRoom>();
        }
        /// <summary>
        /// Method To Get All Details Of Hotel
        /// </summary>
        /// <returns></returns>
        private List<HotelRoom> GetHotelDetails()
        {
            var hotel = hotelroomRepository.All().ToList<HotelRoom>();
            return hotel;
        }
        /// <summary>
        /// Method To Search HotelRoom By Hotelroom Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<HotelRoom> SearchHotelById(int id)
        {
            var hotel = GetHotelDetails();
            var hotelcity = from n in hotel
                            where n.Hotel.HotelId == id
                            select n;
            return hotelcity.ToList<HotelRoom>();
        }
        /// <summary>
        /// Method To Get Total Amount
        /// </summary>
        /// <param name="info"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetTotalBill(SearchInfo info, int id)
        {
            HotelRoom hotelroom = hotelroomRepository.Find(id);
            double billamount = 0.0;
            if (info.NoOfPeople <= info.NoOfRooms * 2)
            {
                billamount = info.NoOfRooms * info.NoOfNight * hotelroom.CostPerDay;
            }
            else
            {
                int extrapeople = info.NoOfPeople - (info.NoOfRooms * 2);
                billamount = info.NoOfRooms * info.NoOfNight * hotelroom.CostPerDay + (extrapeople * 1000 * info.NoOfNight);
            }
            return billamount;
        }

        /// <summary>
        /// Method To Add/Save RoomType In RoomTypeEFRepository
        /// </summary>
        /// <param name="roomtype"></param>
        public void SaveRoomType(RoomType roomtype)
        {
            roomtypeRepository.Create(roomtype);
        }
        /// <summary>
        /// Method To Get List Of RoomType
        /// </summary>
        /// <returns></returns>
        public IList<RoomType> GetRoomType()
        {
            return roomtypeRepository.All().ToList<RoomType>();
        }
        /// <summary>
        /// Method To Delete RoomType By Given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRoomType(int id)
        {
            roomtypeRepository.Delete(id);
        }
        /// <summary>
        /// Method To Return The Object Of RoomType By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoomType EditRoomType(int id)
        {
            return roomtypeRepository.Find(id);
        }
        /// <summary>
        /// Method To Update The RoomType
        /// </summary>
        /// <param name="roomtype"></param>
        public void UpdateRoomType(RoomType roomtype)
        {
            roomtypeRepository.Update(roomtype);
        }
    }
}
