using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class SearchInfo
    {
        [Key]
        public int SearchInfoId { get; set; }
        public long HotelId { get; set; }
        [ForeignKey("HotelId")]
        public virtual Hotel Hotels { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }
        [Range(1, 6, ErrorMessage = "Length should be 1-100")]
        public int NoOfPeople { get; set; }
        [Range(1, 6, ErrorMessage = "Length should be 1-100")]
        public int NoOfRooms { get; set; }
        public int NoOfNight { get; set; }
        public double ExtraCost { get; set; }
    }
}
