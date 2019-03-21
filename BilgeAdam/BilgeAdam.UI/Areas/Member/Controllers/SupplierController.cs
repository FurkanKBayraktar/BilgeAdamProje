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
    public class SupplierController : Controller
    {
        SupplierService _supplierService;
        public SupplierController()
        {
            _supplierService = new SupplierService();
        }
        [BreadCrumb(Clear =true, Label = "Tedarikçiler")]
        public ActionResult List(int page = 1) => View(_supplierService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        
        [HttpGet]
        [BreadCrumb( Label = "Tedarikçi Ekle")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Supplier data)
        {
            if (_supplierService.Any(supplier => supplier.TaxNumber == data.TaxNumber)) return RedirectToAction("List", "Supplier", new { area = "Member" });
            _supplierService.Add(data);
            return RedirectToAction("List", "Supplier", new { area = "Member" });
        }
        [HttpGet]
        [BreadCrumb( Label = "Tedarikçi Güncelle")]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Supplier", new { area = "Member" });

            Supplier data = _supplierService.GetById((Guid)id);
            SupplierVM model = new SupplierVM()
            {
                ID = data.ID,
                SupplierCode = data.SupplierCode,
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
        public ActionResult Update(SupplierVM data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Supplier", new { area = "Member" });
            }

            Supplier supplier = _supplierService.GetById(data.ID);

            supplier.SupplierCode = data.SupplierCode;
            supplier.Name = data.Name;
            supplier.ContactName = data.ContactName;
            supplier.Address = data.Address;
            supplier.TaxNumber = data.TaxNumber;
            supplier.Tax = data.Tax;
            supplier.Phone = data.Phone;
            supplier.Email = data.Email;
            supplier.District = data.District;
            supplier.City = data.City;
            supplier.Country = data.Country;

            _supplierService.Update(supplier);
            return RedirectToAction("List", "Supplier", new { area = "Member" });
        }
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Supplier", new { area = "Member" });

            _supplierService.Remove((Guid)id);

            return RedirectToAction("List", "Supplier", new { area = "Member" });
        }
    }
}