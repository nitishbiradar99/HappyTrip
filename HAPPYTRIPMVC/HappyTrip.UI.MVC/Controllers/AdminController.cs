using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyTrip.UI.MVC.Controllers
{
    public class AdminController : Controller
    {
        
        /// <summary>
        /// Return a view for Admin Dashboard
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}
