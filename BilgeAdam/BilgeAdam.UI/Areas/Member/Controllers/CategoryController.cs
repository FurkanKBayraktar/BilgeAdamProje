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
    public class CategoryController : Controller
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        [BreadCrumb(Clear = true, Label = "Kategoriler")]
        public ActionResult List(int page = 1) => View(_categoryService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        [HttpGet]
        [BreadCrumb( Label = "Kategori Ekle")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category data)
        {
            _categoryService.Add(data);
            return RedirectToAction("List", "Category", new { area = "Member" });
        }
        [HttpGet]
        [BreadCrumb(Label = "Kategori Güncelle")]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Category", new { area = "Member" });
            Category data = _categoryService.GetById((Guid)id);
            CategoryVM model = new CategoryVM()
            {
                ID = data.ID,
                Name = data.Name,
                Description = data.Description

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(CategoryVM data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Category", new { area = "Member" });
            }

            Category category = _categoryService.GetById(data.ID);
            category.Name = data.Name;
            category.Description = data.Description;
            _categoryService.Update(category);
            return RedirectToAction("List", "Category", new { area = "Member" });
        }
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "Category", new { area = "Member" });
            _categoryService.Remove((Guid)id);
            return RedirectToAction("List", "Category", new { area = "Member" });
        }
    }
}