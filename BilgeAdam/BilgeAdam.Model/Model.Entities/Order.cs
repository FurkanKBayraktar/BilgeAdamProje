using BilgeAdam.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Model.Model.Entities
{
    public class Order:CoreEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public bool IsConfirmed { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string OrderCasing { get; set; }


        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
