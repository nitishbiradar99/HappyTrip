using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class BookingContact
    {
        [Key]
        public int BookingContactId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        [Required]
        public int StateId { get; set; }
        public virtual State State { get; set; }
        [Display(Name="Pin Code")]
        [Required]
        [DataType(DataType.PostalCode)]
        public string PinCode { get; set; }
        [Display(Name="Contact Number")]
        [Required]
        public string MobileNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
