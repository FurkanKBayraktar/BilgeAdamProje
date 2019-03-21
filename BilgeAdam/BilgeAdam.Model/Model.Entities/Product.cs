using BilgeAdam.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Model.Model.Entities
{
    public class Product:CoreEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public short UnitsInStock { get; set; }
        public decimal Price { get; set; }
        public string QuantityPerUnit { get; set; }
        public string ImagePath { get; set; }
        public string Barcode { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public Guid SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }

        public ICollection<OrderDetail> OrderDetails  { get; set; }
    }
}
