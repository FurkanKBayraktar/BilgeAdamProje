using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.Orderdetails");

            Property(od => od.UnitPrice).IsOptional();
            Property(od => od.Quantity).IsOptional();
            Property(od => od.KDV).IsOptional();
        }
    }
}
