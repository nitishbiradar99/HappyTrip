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
    public class CityController : Controller
    {
        private ICityManager cityMgr = null;
        //private IStateManager stateMgr = null;
        
        public CityController(ICityManager cityManager)
        {
            this.cityMgr = cityManager;
        }

        /// <summary>
        /// Index action of City Controller
        /// Returns a list of Cities to the view
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            List<City> cities = cityMgr.GetCity().ToList<City>();
            return View(cities.ToPagedList((page?? 1), 8));
        }

        /// <summary>
        /// Get Request of Create action 
        /// Returns a Create view
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(cityMgr.GetAllState(), "StateId", "StateName");
            return View();
        }

        /// <summary>
        /// Post Request of Create action 
        /// Returns Index view if successed
        /// Returns a Create view if fails
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(City city)
        {
            ViewBag.StateId = new SelectList(cityMgr.GetAllState(), "StateId", "StateName");
            if (ModelState.IsValid)
            {
                City DuplicateCity = cityMgr.GetCity().FirstOrDefault(a => city.CityName.ToLower() == a.CityName.ToLower());
                if (DuplicateCity == null)
                {
                    cityMgr.AddCity(city);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "City Name Already Exists");
                }
                
            }
            return View();
            
        }

        /// <summary>
        /// Get Request of Edit Action
        /// Returns a view of City for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            City city = cityMgr.FindCity(id);
            ViewBag.StateId = new SelectList(cityMgr.GetAllState(), "StateId", "StateName", city.StateId);
            return View(city);
        }

        /// <summary>
        /// Post Request of Edit Action
        /// Returns index view if successed
        /// Returns a view of City for a given id if fails
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                cityMgr.EditCity(city);
                ViewBag.EditMessage = "City Edited Sucessfully";
                return RedirectToAction("Index");
            }
            ViewBag.EditMessage = "Something went wrong try again...";
            return View(city);
        }

        /// <summary>
        /// Get Request of Delete Action 
        /// Returns a view of City for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            City city = cityMgr.FindCity(id);
            return View(city);
        }

        /// <summary>
        /// Post Request of Delete Action 
        /// Returns index view if successed
        /// Returns a view of City for a given id if fails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            cityMgr.DeleteCity(id);
            return RedirectToAction("Index");
        }
    }
}
