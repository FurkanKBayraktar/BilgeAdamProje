using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Areas.Member.Models.DTO;
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
    public class CustomerController : Controller
    {
        CustomerService _customerService;
        public CustomerController()
        {
            _customerService = new CustomerService();
        }
        [BreadCrumb(Clear=true, Label = "Müşteriler")]

        public ActionResult List(int page = 1) => View(_customerService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        [HttpGet]
        [BreadCrumb( Label = "Müşteri Ekle")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Customer data)
        {
            if (_customerService.GetActive().Any(customer => customer.TaxNumber == data.TaxNumber)) return RedirectToAction("List", "Customer", new { area = "Member" });
            _customerService.Add(data);
            return RedirectToAction("List", "Customer", new { area = "Member" });
       }
        [HttpGet]
        [BreadCrumb( Label = "Müşteri Güncelle")]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Customer", new { area = "Member" });

            Customer data = _customerService.GetById((Guid)id);
            CustomerVM model = new CustomerVM()
            {
                ID = data.ID,
                CustomerCode = data.CustomerCode,
                Name = data.Name,
                ContactName = data.ContactName,
                Address = data.Address,
                TaxNumber = data.TaxNumber,
                Tax = data.Tax,
                Phone = data.Phone,
                Email = data.Email,
                District = data.District,
                City = data.City,
                Country = data.Country,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(CustomerVM data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Customer", new { area = "Member" });
            }

            Customer customer = _customerService.GetById(data.ID);
  
            customer.CustomerCode = data.CustomerCode;
            customer.Name = data.Name;
            customer.ContactName = data.ContactName;
            customer.Address = data.Address;
            customer.TaxNumber = data.TaxNumber;
            customer.Tax = data.Tax;
            customer.Phone = data.Phone;
            customer.Email = data.Email;
            customer.District = data.District;
            customer.City = data.City;
            customer.Country = data.Country;

            _customerService.Update(customer);
            return RedirectToAction("List", "Customer", new { area = "Member" });
        }
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Customer", new { area = "Member" });

            _customerService.Remove((Guid)id);

            return RedirectToAction("List", "Customer", new { area = "Member" });
        }
    }
}