using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewayBusinessService
{
   public class PaymentDBContext:DbContext
    {
        public DbSet<Payment> Payments { get; set; }
    }
}
