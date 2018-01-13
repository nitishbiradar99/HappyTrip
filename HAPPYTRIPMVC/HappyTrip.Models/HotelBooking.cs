using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class HotelBooking
    {
        [Key]
        public long BookingId { get; set; }
        public int BookingContactId { get; set; }
        public int SearchInfoId { get; set; }
        public DateTime BookingDate { get; set; }
        [ForeignKey("BookingContactId")]
        public virtual HotelBookingContact HotelBookingContacts { get; set; }
        //public string ReferenceNo { get; set; }
        [ForeignKey("SearchInfoId")]
        public virtual SearchInfo SearchInfos { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsCanceled { get; set; }
    }
}
