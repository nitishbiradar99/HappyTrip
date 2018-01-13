using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public Guid BookingNo { get; set; }
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name="Date of Booking")]
        public DateTime BookingDate { get; set; }
        [Required]
        [Display(Name="Amount")]
        public decimal TotalCost { get; set; }
        //public int PaymentID { get; set; }
        //public virtual Payment PaymentInfo { get; set; }
        public bool IsCanceled { get; set; }
        public virtual List<Passenger> Passengers { get; set; }
        public int BookingContactId { get; set; }
        public virtual BookingContact BookingContact { get; set; }
    }
}
