using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Infrastructure.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
   // [Authorize]
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            this.authProvider = auth;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Username, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or Password.");
                    return View();
                }
            }
            return View();
        }

    }
}