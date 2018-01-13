using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [Display(Name="State")]
        public string StateName { get; set; }
        //public virtual  List<City> Cities { get; set; }
    }
}
