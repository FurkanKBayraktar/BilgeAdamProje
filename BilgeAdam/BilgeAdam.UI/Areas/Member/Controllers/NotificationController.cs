using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Member.Controllers
{
    [Role("Member","Admin")]
    public class NotificationController : Controller
    {
        public ActionResult _Notifications()
        {
            AppUserService _appUserService = new AppUserService();

            return View(_appUserService.GetActive().OrderByDescending(x => x.CreatedDate).Take(3));
        }
    }
}