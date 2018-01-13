using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }
        [ForeignKey("FromCity")]
        public int FromCityId { get; set; }
        public City FromCity { get; set; }
        [ForeignKey("ToCity")]
        public int ToCityId { get; set; }
        public City ToCity { get; set; }
        [Display(Name="Distance in Kms")]
        public double DistanceInKms { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual List<Schedule> Schedules { get; set; }
    }
}
