using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.WCFService
{
    public class PaymentServices:IPayment
    {
        PaymentsDBContext db = new PaymentsDBContext();
        public bool SavePayment(Payment payment)
        {

            db.Payments1.Add(payment);
            db.SaveChanges();
            return true;
            //return false;
        }

        //change
        public Payment GetPayment(Payment Payment)
        {
            Payment obj = db.Payments1.Add(Payment);
            return obj;
        }
    }
}
