using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");


            HasRequired(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerID)
                .WillCascadeOnDelete(false);

            HasMany(order => order.OrderDetails)
                .WithRequired(orderDetail => orderDetail.Order)
                .HasForeignKey(orderDetail => orderDetail.OrderID)
                .WillCascadeOnDelete(false);

        }
    }
}
