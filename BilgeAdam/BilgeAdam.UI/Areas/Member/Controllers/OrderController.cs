using BilgeAdam.DAL;
using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Concrete;
using BilgeAdam.UI.Areas.Member.Models;
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
    public class OrderController : Controller
    {
        ProductService _productService;
        AppUserService _appUserService;
        CustomerService _customerService;
        OrderService _orderService;
        OrderDetailService _orderDetailService;
        public OrderController()
        {
            _productService = new ProductService();
            _appUserService = new AppUserService();
            _customerService = new CustomerService();
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
        }
        [HttpGet]
        [BreadCrumb(Clear = true, Label = "Sipariş Oluştur")]
        public ActionResult OrderCreate(string searching)
        {
            return View(_productService.GetDefault(x => x.ProductCode.StartsWith(searching) || x.Name.StartsWith(searching) || searching == null));
        }
        [HttpPost]
        public ActionResult OrderCreate(Product data)//Kasa Satış ve Mobil satış için sipariş oluşturma sayfası
        {
            //Sepet boşsa ana sayfaya yönlendir.
            if (Session["sepet"] == null)
            {
                return RedirectToAction("Index", "Cart", new { area = "Member" });
            }
            //Sepeti yakalıyoruz.
            ProductCart cart = Session["sepet"] as ProductCart;

            //Yeni sipariş oluşturuyoruz.
            Order order = new Order();

            //Siparişin sahibi olan kullanıcının idsini yakaladık.
            order.AppUserID = _appUserService.GetByDefault(x => x.UserName == HttpContext.User.Identity.Name).ID;

            //Sepettki tüm ürünlerde geziyoruz, her ürün için bir sipariş detay oluşturuyoruz(Northwind örneğindeki gibi) ve bu her sipariş detayını siparişe ekliyoruz.
            foreach (var item in cart.CartProductList)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductID = item.ID,
                    Quantity = item.Quantity,

                });
            }
            //Deponun onaylayabilmesi için false yapıyoruz.
            order.IsConfirmed = false;

            _orderService.Add(order);
            
            return RedirectToAction("OrderList", "Order", new { area = "Member" });

        }

        [BreadCrumb(Clear = true, Label = "Siparişler")]
        public ActionResult OrderList(int page = 1)//Depodaki siparişi görüntülemek için
        {
            return View(_orderService.ListPendingOrder().ToPagedList(page, 10));
        }
        public ActionResult Detail(Guid? id)
        {
            if (id == null) return RedirectToAction("OrderList", "Order", new { area = "Member" });


            return View(_orderDetailService.GetDetailsByOrderID((Guid)id));
        }
        public ActionResult ConfirmOrder(Guid id)
        {
            //Sipariş dbden bulunur.
            Order order = _orderService.GetById(id);

            //Sipariş onaylanır.
            order.IsConfirmed = true;

            //Sipariş güncellenir.
            _orderService.Update(order);

            //Siparişin tüm detaylarında gezilir. Her bir detay içerisindeki ürün db.'den yakalanır ve stok miktarı siparişteki miktar kadar düşülür(item.Quantity siparişteki miktardır.). Her ürün tek tek güncellenir.
            foreach (var item in _orderDetailService.GetDetailsByOrderID(id))
            {
                Product p = _productService.GetById(item.ProductID);
                p.UnitsInStock -= item.Quantity;
                _productService.Update(p);
            }
            return RedirectToAction("OrderCreate", "Order", new { area = "Member" });
        }

        public ActionResult RejectOrder(Guid id)
        {
            _orderService.RejectOrder(id);
            return RedirectToAction("OrderCreate", "Order", new { area = "Member" });
        }

    }
}
