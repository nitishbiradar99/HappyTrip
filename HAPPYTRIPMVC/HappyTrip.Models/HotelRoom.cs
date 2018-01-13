using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HappyTrip.Models
{
    public class HotelRoom
    {
        [Key]
        public int HotelRoomId { get; set; }
        public int TypeId { get; set; }
        public long HotelId { get; set; }
        [Required]
        [Display(Name = "Upload Photo")]
        [DataType(DataType.Upload)]
        public byte[] Photo { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public float CostPerDay { get; set; }
        public int NoOfRooms { get; set; }
    }
}
