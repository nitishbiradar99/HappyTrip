using HappyTrip.Business;
using HappyTrip.Models;
using HappyTrip.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace HappyTrip.UI.MVC.Controllers
{
    public class UserLoginController : Controller
    {

        private IUserLoginManager _UserLoginManager = null;
        private IUserRegistrationManager _UserRegistrationManager = null;

        public UserLoginController(IUserLoginManager  usermgr, IUserRegistrationManager regmgr)
        {
            this._UserLoginManager=usermgr;
            this._UserRegistrationManager = regmgr;
        }
       
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home",Session["Message1"]);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
         
            if (_UserLoginManager.Login(user))
            {
                UserRegistration ur = _UserRegistrationManager.GetUser().FirstOrDefault(u => u.Email == user.EmaiID);
                Session["Message1"] =  ur.UserName;
                Session["Message2"] = ur.Email;
                if (ur.Email.ToUpper().Equals("admin@happytrip.com".ToUpper()))
                {
                    return RedirectToAction("Index", "Admin", Session["Message1"]);
                }
                else
                {
                    return RedirectToAction("Index", "User", Session["Message1"]);
                }

            }
            else
                TempData["Message"] = "UserID or Password is invalid";
                return View();
        }
        public ActionResult Logout()
        {
            Session["Message1"] = "";
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}
