using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HappyTrip.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage="Name can not be exceed more than 100 characters")]
        [Display(Name="Name")]
        public string FullName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
