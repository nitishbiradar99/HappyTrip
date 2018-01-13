using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card Number should be of 16 length")]
        public string CardNo { get; set; }
        [Required]
        [Display(Name="Card Holder Name")]
        public string CardHolderName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date of Issue")]
        public DateTime IssueDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date of Expiry")]
        public DateTime ExpiryDate { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV Length should be 3")]
        public string CVV { get; set; }
    }
}
