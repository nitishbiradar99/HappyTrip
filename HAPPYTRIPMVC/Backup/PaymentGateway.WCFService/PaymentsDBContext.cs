using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.WCFService
{
   
        public class PaymentsDBContext : DbContext
        {

            public DbSet<Payment> Payments1 { get; set; }

        }
    
}
