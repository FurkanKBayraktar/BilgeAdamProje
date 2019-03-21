using BilgeAdam.Core.Core.Entity.Enum;
using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BilgeAdam.UI.Controllers
{
    public class AccountController : Controller
  {
        AppUserService _appUserService;
        public AccountController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserService.GetByDefault(x => x.UserName == HttpContext.User.Identity.Name);

                if (user.Role == Role.Admin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (user.Role == Role.Member)
                {
                    return RedirectToAction("Index", "Home", new { area = "Member" });
                }

            }
            return View();
        }



        [HttpPost]
        public ActionResult Register(AppUser data)
        {
            data.Role = Role.Member;
            data.ImagePath = "/Uploads/anon.png";
            _appUserService.Add(data);

            return RedirectToAction("Login", "Account");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserService.GetByDefault(x => x.UserName == HttpContext.User.Identity.Name);

                if (user.Role == Role.Admin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (user.Role == Role.Member)
                {
                    return RedirectToAction("Index", "Home", new { area = "Member" });
                }

            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                var user = _appUserService.GetByDefault(x => x.UserName == data.UserName && x.Password == data.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, data.isPersistent);

                    if (user.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (user.Role == Role.Member)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Member" });
                    }
                }

            }
            ViewBag.Message = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }
    }
}
