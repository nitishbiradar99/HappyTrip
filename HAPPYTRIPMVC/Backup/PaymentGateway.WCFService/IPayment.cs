using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.WCFService
{
    [ServiceContract]
    public interface IPayment
    {
        [OperationContract]
        bool SavePayment(Payment payment);
        [OperationContract]
        Payment GetPayment(Payment Payment);
    }
}
