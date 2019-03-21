using BilgeAdam.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
       [Role("Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}