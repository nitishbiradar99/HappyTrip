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
    public class StateController : Controller
    {
        private IStateManager stateManager = null;

        public StateController(IStateManager stateMgr)
        {
            this.stateManager = stateMgr;
        }

        /// <summary>
        /// Index Method for state Controller
        /// Return a view with a list of All State
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            List<State> state = stateManager.GetState().ToList<State>();
            return View(state.ToPagedList((page ?? 1), 8));
        }

        /// <summary>
        /// Get Request for Create MEthod
        /// REturn a create view for State
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Request for Create State Method
        /// Return Index view if successed
        /// Return Create view if fails
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                State DuplicateState = stateManager.GetState().FirstOrDefault(p => p.StateName.ToLower() == state.StateName.ToLower());
                if (DuplicateState == null)
                {
                    stateManager.AddState(state);
                    return RedirectToAction("Index");
                }
                else 
                {
                    ModelState.AddModelError("", "State already exists");
                }
            }
            return View();
        }

        /// <summary>
        /// Get Request for Edit Method of State Controller
        /// Return a view of State for a given Id
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            State state = stateManager.FindState(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        /// <summary>
        /// Post Request of Edit Method of State Controller
        /// Return Index View if Successed
        /// Return a view of State for a given Id if fails
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(State r)
        {
            if (ModelState.IsValid)
            {
                stateManager.EditState(r);
                ViewBag.EditMessage = "State Edited Sucessfully";
                return RedirectToAction("Index");
            }
            ViewBag.EditMessage = "Something went wrong try again...";
            return View(r);
        }

        /// <summary>
        /// Get Request for Delete Method of State Controller
        /// Return a view of State for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            State r = stateManager.FindState(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        /// <summary>
        /// Post Request for Delete Method of State Controller
        /// Return index view of State if successed
        /// Return a view of State for a given id if fails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id = 0)
        {
            State r = stateManager.FindState(id);
            stateManager.DeleteState(r);
            return RedirectToAction("Index");
        }
    }
}
