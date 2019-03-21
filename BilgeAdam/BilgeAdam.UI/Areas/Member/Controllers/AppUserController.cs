using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Areas.Member.Models.DTO;
using BilgeAdam.UI.Attributes;
using BilgeAdam.Utility;
using MvcBreadCrumbs;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Member.Controllers
{

   [Role("Member","Admin")]
    public class AppUserController : Controller
    {
        AppUserService _appUserService;
        DepartmentService _departmentService;
        StoreService _storeService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
            _departmentService = new DepartmentService();
            _storeService = new StoreService();
        }
        [BreadCrumb(Clear =true, Label = "Personel")]
        public ActionResult List(int page = 1) => View(_appUserService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        [HttpGet]
        [BreadCrumb(Label = "Personel Ekle")]
        public ActionResult Add()
        {
            TempData["DepartmentListesi"] = _departmentService.GetActive();
            TempData["StoreListesi"] = _storeService.GetActive();
            return View();
        }
        [HttpPost]
        public ActionResult Add(AppUser data, HttpPostedFileBase Image)
        {
            if (_appUserService.GetActive().Any(appUser => appUser.UserName == data.UserName)) return RedirectToAction("List", "AppUser", new { area = "Member" });
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);
            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                data.ImagePath = "/Uploads/anon.png";
            }
            _appUserService.Add(data);
            return RedirectToAction("List", "AppUser", new { area = "Member" });
        }
        [HttpGet]
        [BreadCrumb(Label = "Personel Güncelle")]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "AppUser", new { area = "Member" });
            AppUser data = _appUserService.GetById((Guid)id);
            AppUserVM model = new AppUserVM()
            {
                ID = data.ID,
                UserName = data.UserName,
                Password = data.Password,
                Gender = data.Gender,
                Address = data.Address,
                IdentityNumber = data.IdentityNumber,
                Name = data.Name,
                LastName = data.LastName,
                Salary = data.Salary,
                Email = data.Email,
                Phone = data.Phone,
                District = data.District,
                City = data.City,
                Country = data.Country,
                Birthdate = data.Birthdate,
                ImagePath = data.ImagePath,
                DepartmentID = data.DepartmentID,
                StoreID = data.StoreID,            
            };


            TempData["DepartmentListesi"] = _departmentService.GetActive();
            TempData["StoreListesi"] = _storeService.GetActive();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(AppUserVM data,HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "AppUser", new { area = "Member" });
            }

            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);
            AppUser appUser = _appUserService.GetById(data.ID);
            if (data.ImagePath != "0" && data.ImagePath != "1" && data.ImagePath != "2")
            {
                appUser.ImagePath = data.ImagePath;
            }
            appUser.UserName = data.Name;
            appUser.Password = data.Password;
            appUser.Gender = data.Gender;
            appUser.Address = data.Address;
            appUser.IdentityNumber = data.IdentityNumber;
            appUser.Name = data.Name;
            appUser.LastName = data.LastName;
            appUser.Salary = data.Salary;
            appUser.Email = data.Email;
            appUser.Phone = data.Phone;
            appUser.District = data.District;
            appUser.City = data.City;
            appUser.Country = data.Country;
            appUser.Birthdate = data.Birthdate;
            appUser.DepartmentID = data.DepartmentID;
            appUser.StoreID = data.StoreID;
            _appUserService.Update(appUser);
            return RedirectToAction("List", "AppUser", new { area = "Member" });
        }
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "AppUser", new { area = "Member" });
            _appUserService.Remove((Guid)id);
            return RedirectToAction("List", "AppUser", new { area = "Member" });
        }
    }
}