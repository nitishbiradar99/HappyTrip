using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
   public class FlightCost
    {
       [Key]
       public int FlightCostId { get; set; }
       [Required]
       public int TravelClassId { get; set; }
       public virtual TravelClass TravelClass { get; set; }
       [Required]
       public int ScheduleId { get; set; }
       public Schedule Schedule { get; set;}
       [Required]
       [Display(Name="Cost Of Ticket")]
       public decimal CostPerTicket { get; set; }
    }
}
