using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Member.Models.DTO
{
    public class ProductVM
    {
        public Guid ID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public short UnitsInStock { get; set; }
        public decimal Price { get; set; }
        public string QuantityPerUnit { get; set; }
        public string ImagePath { get; set; }
        public string Barcode { get; set; }

        public Guid CategoryID { get; set; }
        public Guid SupplierID { get; set; }
    }
}