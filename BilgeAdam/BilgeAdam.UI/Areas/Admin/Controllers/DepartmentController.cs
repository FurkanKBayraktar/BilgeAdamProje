using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Areas.Admin.Models.DTO;
using BilgeAdam.UI.Attributes;
using MvcBreadCrumbs;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Admin.Controllers
{
   [Role("Admin")]
    public class DepartmentController : Controller
    {
        DepartmentService _departmentService;
        public DepartmentController()
        {
            _departmentService = new DepartmentService();
        }

        [BreadCrumb(Clear = true, Label = "Kullanıcı Grupları")]
        public ActionResult List(int page = 1) => View(_departmentService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        [HttpGet]
        [BreadCrumb(Label = "Grup Ekle")]

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department data)
        {
            _departmentService.Add(data);
            return RedirectToAction("List", "Department", new { area = "Admin" });

        }
        [HttpGet]
        [BreadCrumb(Label = "Grup Güncelle")]

        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Department", new { area = "Admin" });

            Department guncellenecek = _departmentService.GetById((Guid)id);
            DepartmentVM model = new DepartmentVM()
            {
                ID = guncellenecek.ID,
                DepartmentName = guncellenecek.DepartmentName,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DepartmentVM data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Department", new { area = "Admin" });
            }

            Department department = _departmentService.GetById(data.ID);
            department.DepartmentName = data.DepartmentName;
            _departmentService.Update(department);
            return RedirectToAction("List", "Department", new { area = "Admin" });
        }
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Department", new { area = "Admin" });

            _departmentService.Remove((Guid)id);

            return RedirectToAction("List", "Department", new { area = "Admin" });
        }
    }
}