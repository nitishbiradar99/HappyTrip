using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyTrip.Business;
using HappyTrip.Models;
using HappyTrip.Business.Contracts;

namespace HappyTrip.UI.MVC.Controllers
{
    //[Authorize]
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        private IPaymentManager paymentMgr = null;

        public PaymentController(IPaymentManager paymentMgr)
        {
            this.paymentMgr = paymentMgr;
        }

        public ActionResult CreatePayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePayment(Payment Payment)
        {
            if (Payment.IssueDate >= DateTime.Now)
            {
                TempData["Msg"] = "Issue Date must be less than Current Date";
                return View();
            }

            else if (Payment.IssueDate >= Payment.ExpiryDate)
            {
                TempData["Msg"] = "Issue Date must be less than Expiry Date";
                return View();
            }

            else if (Payment.ExpiryDate <= DateTime.Now)
            {
                TempData["Msg"] = "Expiry Date must be greater than Current Date";
                return View();
            }

            else
            {
                //paymentMgr.SavePayment(Payment);
                TempData["PaymentData"] = paymentMgr.GetPayment(Payment);
                return RedirectToAction("OTP");
            }
        }

        public ActionResult OTP()
        {
            Payment payment = TempData["PaymentData"] as Payment;
            TempData["PaymentData1"] = payment;
            return View();
        }

        public ActionResult ValidateOTP(FormCollection form)
        {
            Payment payment = TempData["PaymentData1"] as Payment;
            string OTP = "123456";
            string otp = Request.Form["OTP"];

            if (!(OTP.Equals(otp)))
            {
                TempData["Msg"] = "Invalid OTP";
                return RedirectToAction("OTP");
            }
            else
            {
                paymentMgr.SavePayment(payment);
                return View();
            }
        }
    }
}
