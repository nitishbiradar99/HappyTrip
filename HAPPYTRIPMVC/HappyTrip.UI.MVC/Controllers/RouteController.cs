using HappyTrip.Business;
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
    public class RouteController : Controller
    {
        private IRouteManager routeManager = null;

        public RouteController(IRouteManager routeMmnager)
        {
            this.routeManager = routeMmnager;
        }

        /// <summary>
        /// Home page for Route
        /// Returns list of route from DbContext
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            List<Route> routes = routeManager.GetRoute().ToList<Route>();

            foreach (var a in routeManager.GetRoute())
            {
                a.ToCity = routeManager.GetAllCities().Find(p => p.CityId == a.FromCityId);
                a.FromCity = routeManager.GetAllCities().Find(p => p.CityId == a.ToCityId);
            }

            return View(routes.ToPagedList((page ?? 1), 8));
        }

        /// <summary>
        /// Method to add a route 
        /// returns a create view for Route
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.FromCityId = new SelectList(routeManager.GetAllCities(), "CityId", "CityName");
            ViewBag.ToCityId = new SelectList(routeManager.GetAllCities(), "CityId", "CityName");
            return View();
        }

        /// <summary>
        /// Post method of Create Route
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Route route)
        {
            if (ModelState.IsValid)
            {
                routeManager.AddRoute(route);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Input was not correct please try again...");
            return View();
        }

        /// <summary>
        /// Edit method for Route
        /// Return the view of route 
        /// for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id=0)
        {
            Route route = routeManager.FindRoute(id);
            ViewBag.FromCityId = new SelectList(routeManager.GetAllCities(), "CityId", "CityName", route.FromCityId);
            ViewBag.ToCityId = new SelectList(routeManager.GetAllCities(), "CityId", "CityName", route.ToCityId);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        /// <summary>
        /// Post method for Edit 
        /// if successed return the view of Index Page
        /// if fails return the view of edit page
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Route r)
        {
            if (ModelState.IsValid)
            {
                routeManager.EditRoute(r);
                ViewBag.EditMessage = "Route Edited Sucessfully";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something went wrong try again...");
            return View(r);
        }

        /// <summary>
        /// Delete method for Route
        /// Returns the view of Route 
        /// for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id=0)
        {
            Route r = routeManager.FindRoute(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        /// <summary>
        /// Post method of Delete Route
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id = 0)
        {
            try
            {
                Route r = routeManager.FindRoute(id);
                routeManager.DeleteRoute(r);
                return RedirectToAction("Index");
            }
            catch 
            {
                ViewBag.ErrorMsg = "Something went wrong please try again...";
                return RedirectToAction("Delete", id);
            }
        }
    }
}
