using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Areas.Member.Models;
using BilgeAdam.UI.Areas.Member.Models.DTO;
using BilgeAdam.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Areas.Member.Controllers
{
    [Role("Member")]
    public class CartController : Controller
    {
        ProductService _productService;
        public CartController()
        {
            _productService = new ProductService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                List<CartProductVM> productList = cart.CartProductList.Select(x => new CartProductVM
                {
                    ID = x.ID,
                    ProductCode=x.ProductCode,
                    Name = x.Name,
                    Quantity = x.Quantity
                }).ToList();
                //Server get isteğini reddedebilir. Bu nedenle AllowGet komutu yazılmalıdır.
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            return Json("Empty", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(Guid id)
        {
           
            //gelen id'ye ait ürünü yakalıyoruz.
            Product sepeteEklenecekUrun = _productService.GetById(id);

            CartProductVM model = new CartProductVM
            {
                ID = sepeteEklenecekUrun.ID,
                ProductCode= sepeteEklenecekUrun.ProductCode,
                Name = sepeteEklenecekUrun.Name,
                Quantity = 1
            };

            //Session Nedir ? 
            //Server taraflı verileri tutmak için tasarlanmış bir yapıdır.
            //Kullanıcı oturumlarını, sepet vb yapıları client-server iletişimi sırasında saklamamıza yarar.
            //Session object tipinde değer tutar bu nedenle cast etmek gereklidir.
            if (Session["sepet"] != null)
            {
                //Eğer sepet varsa, session içerisinden o sepeti getiriyorum.
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(model);

                //Ürün eklendikten sonra yeni sepeti tekrar session'a atıyoruz
                Session["sepet"] = cart;
            }
            else
            {
                //eğer session içerisinde sepet yoksa yenisi oluşturulur.
                ProductCart cart = new ProductCart();
                cart.AddCart(model);
                Session.Add("sepet", cart);
                Session["sepet"] = cart;
            }

            //İsterseniz mesaj gönderebilirsiniz.
            return Json("Sepete başarıyla eklendi!");

        }

        public ActionResult IncreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.IncreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }
        public ActionResult DecreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }
        public ActionResult Remove(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.RemoveCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }
    }
}
