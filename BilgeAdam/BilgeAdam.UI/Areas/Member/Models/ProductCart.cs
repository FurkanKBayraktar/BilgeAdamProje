using BilgeAdam.UI.Areas.Member.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Member.Models
{
    public class ProductCart
    {

        private Dictionary<Guid, CartProductVM> _cart = null;

        public ProductCart()
        {
            _cart = new Dictionary<Guid, CartProductVM>();
        }

        public List<CartProductVM> CartProductList
        {
            get
            {
              
                return _cart.Values.ToList();
            }
        }


        #region Sepete Ürün Ekleme

        public void AddCart(CartProductVM item)
        {
           
            if (!_cart.ContainsKey(item.ID))
            {
                _cart.Add(item.ID, item);
            }
            else
            {
                _cart[item.ID].Quantity++;
            }
        }
        #endregion

        #region Sepetten Ürün Silme
        public void RemoveCart(Guid id)
        {
            _cart.Remove(id);
        }
        #endregion

        #region Sepetteki Ürün Miktarını Azaltma
        public void DecreaseCart(Guid id)
        {
            _cart[id].Quantity--;
            if (_cart[id].Quantity <= 0) _cart.Remove(id);
        }
        #endregion

        #region Sepetteki Ürün Miktarını Arttırma
        public void IncreaseCart(Guid id)
        {
            _cart[id].Quantity++;
        }
        #endregion

        #region Sepete Toplu Ürün Ekleme
        public void IncreaseCart(Guid id, short quantity)
        {
          
            _cart[id].Quantity += quantity;
        }

        #endregion
    }
}