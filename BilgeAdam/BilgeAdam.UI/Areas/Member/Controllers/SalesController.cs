using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Attributes;
using MvcBreadCrumbs;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Member.Controllers
{
   [Role("Member")]
    public class SalesController : Controller
    {
        
        CustomerService _customerService;
        public SalesController()
        {
            _customerService = new CustomerService();
        }
        [BreadCrumb(Clear = true, Label = "Satış Yap")]
        public ActionResult Sell(string searching, int page = 1)
        {
            return View(_customerService.GetDefault(x =>x.TaxNumber.StartsWith(searching) || x.Name.StartsWith(searching)|| x.ContactName.StartsWith(searching) || searching == null).OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        }
    }
}