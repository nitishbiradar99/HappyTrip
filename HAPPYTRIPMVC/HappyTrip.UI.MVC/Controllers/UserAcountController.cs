﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using HappyTrip.UI.MVC.Filters;
using HappyTrip.UI.MVC.Models;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace HappyTrip.UI.MVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class UserAcountController : Controller
    {
        private IUserAcountManager useracountManager = null;
        public UserAcountController(IUserAcountManager useracountmanager)
        {
           this.useracountManager = useracountmanager;
        }
        #region No Need
        //
        // GET: /UserAcount/
        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(HappyTrip.Models.LoginModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
        //    {
        //        return RedirectToLocal(returnUrl);
        //    }
        //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    WebSecurity.Logout();
        //    return RedirectToAction("Index", "Home");
        //}
#endregion


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(user.UserName, user.Password);
                    WebSecurity.Login(user.UserName, user.Password);
                    useracountManager.SaveUserDetails(user);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }
            // If we got this far, something failed, redisplay form
            return View(user);
        }

        #region No need
        //
        // GET: /UserAcount/Manage
        //public ActionResult Manage(ManageMessageId? message)
        //{
        //    ViewBag.StatusMessage =
        //        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
        //        : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
        //        : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        //        : "";
        //    ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    return View();
        //}

        ////
        //// POST: /Account/Manage

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Manage(HappyTrip.Models.LocalPasswordModel model)
        //{
        //    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
        //    ViewBag.HasLocalPassword = hasLocalAccount;
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    if (hasLocalAccount)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // ChangePassword will throw an exception rather than return false in certain failure scenarios.
        //            bool changePasswordSucceeded;
        //            try
        //            {
        //                changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
        //            }
        //            catch (Exception)
        //            {
        //                changePasswordSucceeded = false;
        //            }

        //            if (changePasswordSucceeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // User does not have a local password so remove any validation errors caused by a missing
        //        // OldPassword field
        //        ModelState state = ModelState["OldPassword"];
        //        if (state != null)
        //        {
        //            state.Errors.Clear();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
        //            }
        //            catch (Exception e)
        //            {
        //                ModelState.AddModelError("", e);
        //            }
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}
        #endregion

        #region Helper Method
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
