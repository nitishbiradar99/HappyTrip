using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business
{
    public class PaymentManager:IPaymentManager
    {
        //public bool SavePayment(Models.Payment payment)
        //{
        //    PaymentReference.IPayment _proxy = new PaymentReference.PaymentClient();
        //    bool flag = false;
        //    if (_proxy.SavePayment(payment))
        //    {
        //        flag = true;
        //        return flag;
        //    }
        //    else
        //    {
        //        return flag;
        //    }
        //}

        //public Models.Payment GetPayment(Models.Payment payment)
        //{
        //    PaymentReference.IPayment _proxy = new PaymentReference.PaymentClient();
        //    Payment obj = _proxy.GetPayment(payment);
        //    return obj;
        //}


        public bool SavePayment(Payment payment)
        {
            PaymentGatewayBusinessService.PaymentServices _proxy = new PaymentGatewayBusinessService.PaymentServices();
            bool flag = false;
            if (_proxy.SavePayment(payment))
            {
                flag = true;
                return flag;
            }
            else
            {
                return flag;
            }
            throw new NotImplementedException();
        }

        public Payment GetPayment(Payment payment)
        {
            PaymentGatewayBusinessService.PaymentServices _proxy = new PaymentGatewayBusinessService.PaymentServices();
            Payment obj = _proxy.GetPayment(payment);
            return obj;
            throw new NotImplementedException();
        }
    }
}
