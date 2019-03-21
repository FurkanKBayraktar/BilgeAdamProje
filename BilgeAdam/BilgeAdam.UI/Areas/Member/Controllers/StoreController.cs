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
    public class StoreController : Controller
    {
        StoreService _storeService;
        public StoreController()
        {
            _storeService = new StoreService();
        }
        [BreadCrumb(Clear=true, Label = "Şubeler")]
        public ActionResult List(int page = 1) => View(_storeService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        [HttpGet]
        [BreadCrumb( Label = "Şube Ekle")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Store data)
        {
            _storeService.Add(data);
            return RedirectToAction("List", "Store", new { area = "Member" });
        }
        [HttpGet]
        [BreadCrumb( Label = "Şube Güncelle")]
        public ActionResult Update(Guid? id)
        {
            if (id == null) RedirectToAction("List", "Store", new { area = "Member" });
            Store data = _storeService.GetById((Guid)id);
            StoreVM model = new StoreVM()
            {
                ID = data.ID,
                Name = data.Name,
                Address = data.Address,
                Phone = data.Phone,
                Email = data.Email,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(StoreVM data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Store", new { area = "Member" });
            }
            Store store = _storeService.GetById(data.ID);
            store.Name = data.Name;
            store.Address = data.Address;
            store.Phone = data.Phone;
            store.Email = data.Email;
            _storeService.Update(store);
            return RedirectToAction("List", "Store", new { area = "Member" });
        }
        public ActionResult Delete(Guid? id)
        {
            if (id==null) RedirectToAction("List", "Store", new { area = "Member" });

            _storeService.Remove((Guid)id);
            return RedirectToAction("List", "Store", new { area = "Member" });
        }
    }
}