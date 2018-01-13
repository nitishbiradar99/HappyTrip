using HappyTrip.Business;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HappyTrip.UI.MVC.Controllers
{
    
    public class UserRegistrationController : Controller
    {

        private IUserRegistrationManager _UserRegistrationManager = null;

        public UserRegistrationController(IUserRegistrationManager  usermgr)
        {
            this._UserRegistrationManager=usermgr;
        }


        public ActionResult Index()
        {
            List<UserRegistration> _users = _UserRegistrationManager.GetUser().ToList<UserRegistration>();
            return View(_users);
        }

        [HttpGet]
        public ActionResult Create()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserRegistration user)
        {
            if (_UserRegistrationManager.SaveUser(user))
            {
                TempData["Message"] = user.Email + " " + "Added Successfully";
                return RedirectToAction("Index", "UserLogin");
                //if (user.Email == "admin@gmail.com")
                //{
                //    return RedirectToAction("Index", "User");
                //}
                //else {
                //    return RedirectToAction("Index","Admin");
                //}
            }
            else
                TempData["Message"] = "Allready Registered with the " + user.Email + "in the Application ";
                return View();
        }

        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            UserRegistration user = _UserRegistrationManager.FindUser(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserRegistration user)
        {
            _UserRegistrationManager.SaveChange(user);
             return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            UserRegistration user = _UserRegistrationManager.FindUser(id);
            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteUserConfirm(int id)
        {
            _UserRegistrationManager.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            UserRegistration user = _UserRegistrationManager.FindUser(id);
            return View(user);
        }
    }
}
