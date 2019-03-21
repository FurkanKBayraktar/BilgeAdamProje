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
  [Role("Member")]
    public class ProductController : Controller
    {
        ProductService _productService;
        CategoryService _categoryService;
        SupplierService _supplierService;
        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            _supplierService = new SupplierService();
        }
        [BreadCrumb(Clear = true, Label = "Ürünler")]
        public ActionResult List(int page = 1) => View(_productService.GetActive().OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10));
        [HttpGet]
        [BreadCrumb(Label = "Ürün Ekle")]
        public ActionResult Add()
        {

            TempData["KategoriListesi"] = _categoryService.GetActive();
            TempData["TedarikciListesi"] = _supplierService.GetActive();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product data, HttpPostedFileBase Image)
        {
            if (_productService.GetActive().Any(product => product.ProductCode == data.ProductCode)) return RedirectToAction("List", "Product", new { area = "Member" });
            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                data.ImagePath = "/Uploads/images.jpg";
            }
            _productService.Add(data);
            return RedirectToAction("List", "Product", new { area = "Member" });
        }
        [HttpGet]
        [BreadCrumb(Label = "Ürün Güncelle")]
        public ActionResult Update(Guid? id)
        {
            if (id == null) RedirectToAction("List", "Product", new { area = "Member" });
            Product data = _productService.GetById((Guid)id);
            ProductVM model = new ProductVM()
            {
                ID = data.ID,
                ProductCode = data.ProductCode,
                Name = data.Name,
                UnitsInStock = data.UnitsInStock,
                Price = data.Price,
                QuantityPerUnit = data.QuantityPerUnit,
                ImagePath = data.ImagePath,
                Barcode = data.Barcode,
                CategoryID = data.CategoryID,
                SupplierID = data.SupplierID,
            };
            TempData["KategoriListesi"] = _categoryService.GetActive();
            TempData["TedarikciListesi"] = _supplierService.GetActive();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(ProductVM data, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Product", new { area = "Member" });
            }
            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);
            Product product = _productService.GetById(data.ID);
            if (data.ImagePath != "0" && data.ImagePath != "1" && data.ImagePath != "2")
            {
                product.ImagePath = data.ImagePath;
            }
            product.ProductCode = data.ProductCode;
            product.Name = data.Name;
            product.UnitsInStock = data.UnitsInStock;
            product.Price = data.Price;
            product.QuantityPerUnit = data.QuantityPerUnit;
            product.Barcode = data.Barcode;
            product.CategoryID = data.CategoryID;
            product.SupplierID = data.SupplierID;
            _productService.Update(product);
            return RedirectToAction("List", "Product", new { area = "Member" });
        }
        public ActionResult Delete(Guid? id)
        {
            if (id == null) RedirectToAction("List", "Product", new { area = "Member" });
            _productService.Remove((Guid)id);
            return RedirectToAction("List", "Product", new { area = "Member" });
        }
        public ActionResult ListCount(string searching)
        {
            return View(_productService.GetActive().Where(x => x.UnitsInStock.Equals(searching) || searching == null));/*_productService.GetDefault(x=>x.UnitsInStock.Equals(searching) || searching == null)*/
        }
    }
}