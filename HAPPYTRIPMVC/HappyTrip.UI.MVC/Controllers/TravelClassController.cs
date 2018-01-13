using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace HappyTrip.UI.MVC.Controllers
{
    public class TravelClassController : Controller
    {
        private ITravelClassManager tcmgr = null;

        public TravelClassController(ITravelClassManager travelclassManager)
        {
            this.tcmgr = travelclassManager;
        }

        /// <summary>
        /// Home page for Travel Class
        /// returns a view of List of All Travel Class
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            List<TravelClass> travelClass = tcmgr.GetTravelClass().ToList<TravelClass>();
            return View(travelClass.ToPagedList((page ?? 1), 8));
        }

        /// <summary>
        /// Get Request for Create a Travel Class
        /// Returns a create view for Travel Class
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Request for Create a Travel Class
        /// Return Index View of Travel Class if Sucessed
        /// Return Create View of Travel Class if fails 
        /// </summary>
        /// <param name="tc"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(TravelClass tc)
        {
            if (ModelState.IsValid)
            {
                TravelClass DuplicateTC = tcmgr.GetTravelClass().FirstOrDefault(p => p.TravelClassName.ToLower() == tc.TravelClassName.ToLower());
                if (DuplicateTC == null)
                {
                    tcmgr.AddTravelClass(tc);
                    return RedirectToAction("Index");
                }
                else 
                {
                    ModelState.AddModelError("", "Travel Class already exists");
                }
            }
            return View();
        }

        /// <summary>
        /// Edit Method of Travel Class
        /// Returns a View for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            TravelClass tc = tcmgr.FindTravelClass(id);
            ViewBag.EditMessage = "";
            return View(tc);
        }

        /// <summary>
        /// Post Method of Edit of Travel Class
        /// Returns Index view if sucessed
        /// Return Edit view if fails
        /// </summary>
        /// <param name="tc"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(TravelClass tc)
        {
            if (ModelState.IsValid)
            {
                tcmgr.EditTravelClass(tc);
                TempData["EditMessage"] = "TravelClass Edited Sucessfully";
                return RedirectToAction("Index");
            }
            ViewBag.EditMessage = "Something went wrong try again...";
            return View(tc);
        }

        /// <summary>
        /// Delete Method of Travel Class
        /// Return a view for Travel Class for a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            TravelClass tc = tcmgr.FindTravelClass(id);
            return View(tc);
        }

        /// <summary>
        /// Post Request for Delete Action
        /// Return Index View If Sucessed
        /// Return Delete View if Fails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                tcmgr.DeleteTravelClass(id);
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
