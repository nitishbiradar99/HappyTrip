using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class CancelBookingHotel
    {
        [Key]
        public int CancelBookingId { get; set; }
        [Required]
        public int BookingIdNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
    }
}
