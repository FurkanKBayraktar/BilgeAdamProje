using BilgeAdam.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Member.Controllers
{
   [Role("Member")]
    public class InvoiceController : Controller
    {
        // GET: Member/Invoice
        public ActionResult Index()
        {
            return View();
        }
    }
}