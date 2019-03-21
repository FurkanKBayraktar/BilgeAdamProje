using BilgeAdam.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Model.Model.Entities
{
    public class OrderDetail:CoreEntity
    {
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public float KDV { get; set; }

        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }

        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
