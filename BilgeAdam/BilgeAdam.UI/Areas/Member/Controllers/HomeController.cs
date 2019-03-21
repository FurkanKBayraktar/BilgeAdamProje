
using BilgeAdam.UI.Attributes;
using MvcBreadCrumbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Member.Controllers
{
   [Role("Member")]
    public class HomeController : Controller
    {

        [BreadCrumb(Clear = true, Label = "Anasayfa")]
        public ActionResult Index()
        {
            return View();
        }
    }
}