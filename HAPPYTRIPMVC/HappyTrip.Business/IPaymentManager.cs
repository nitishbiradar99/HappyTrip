using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface IPaymentManager
    {
        bool SavePayment(Payment payment);
        Payment GetPayment(Payment payment);
    }
}
