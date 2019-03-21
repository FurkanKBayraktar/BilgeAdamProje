using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Member.Models.DTO
{
    public class CartProductVM
    {
        public Guid ID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        //Sepetteki ürün miktarı içindir. Veritabanındaki yani product sınıfımızdaki quantityPerUnit ile alakası yoktur.
        public short Quantity { get; set; }
    }
}