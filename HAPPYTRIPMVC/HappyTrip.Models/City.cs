using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Display(Name="City")]
        [Required]
        public string CityName { get; set; }
        [Required]
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
