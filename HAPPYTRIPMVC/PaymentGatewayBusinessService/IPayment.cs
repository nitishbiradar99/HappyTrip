using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewayBusinessService
{
    public interface IPayment
    {
        bool SavePayment(Payment payment);
       
        Payment GetPayment(Payment Payment);
    }
}
