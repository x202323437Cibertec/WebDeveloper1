using Cibertec.MVC.Models;
using Cibertec.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.MVC.Controllers
{
    public class AccountController : BaseController
    {

        public AccountController(ILog pLog, IUnitOfWork pUnit) : base(pLog, pUnit) { }

        [AllowAnonymous]
        public ActionResult Login(string pReturnURL)
        {
            return View(new UserViewModel { ReturnURL = pReturnURL });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(UserViewModel pUser)
        {
            if (!ModelState.IsValid) return View(pUser);
            var validUser = _unit.Users.ValidaterUser(pUser.Email, pUser.Password);
            if (validUser == null)
            {
                ModelState.AddModelError("Error", "Usuario o clave no valido");
                return View(pUser);
            }
            var identity = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Email, validUser.Email),
                                             new Claim(ClaimTypes.Role , validUser.Roles),
                                             new Claim(ClaimTypes.Name , $"{validUser.FirstName} {validUser.LastName}"),
                                             new Claim(ClaimTypes.NameIdentifier, validUser.Id.ToString())}, "ApplicationCookie");
            var context = Request.GetOwinContext();
            var authmanager = context.Authentication;
            authmanager.SignIn(identity);
            return RedirecToLocal(pUser.ReturnURL);
        }

        public ActionResult Logout()
        { 
            var context = Request.GetOwinContext();
            var authmanager = context.Authentication;
            authmanager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirecToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}