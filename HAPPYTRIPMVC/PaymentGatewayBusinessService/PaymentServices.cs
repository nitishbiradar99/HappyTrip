using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewayBusinessService
{
    public class PaymentServices:IPayment
    {
        PaymentDBContext db = new PaymentDBContext();
        public bool SavePayment(Payment payment)
        {

            db.Payments.Add(payment);
            db.SaveChanges();
            return true;
            //return false;
        }

        //change
        public Payment GetPayment(Payment Payment)
        {
            Payment obj = db.Payments.Add(Payment);
            return obj;
        }
    }
}
