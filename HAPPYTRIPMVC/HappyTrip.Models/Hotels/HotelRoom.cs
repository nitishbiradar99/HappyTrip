using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class HotelRoom
    {
        [Key]
        public int HotelRoomId { get; set; }
        public RoomType RoomType { get; set; }
        public float CostPerDay { get; set; }
        public int NoOfRooms { get; set; }
    }
}
