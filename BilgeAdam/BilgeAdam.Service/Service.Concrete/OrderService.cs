using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Service.Service.Concrete
{
    public class OrderService:BaseService<Order>
    {
        
        public int PendingOrderCount() => GetDefault(x => x.IsConfirmed == false && (x.Status == Core.Core.Entity.Enum.Status.Active || x.Status == Core.Core.Entity.Enum.Status.Updated)).Count;

        public List<Order> ListPendingOrder() => GetDefault(x => x.IsConfirmed == false && (x.Status == Core.Core.Entity.Enum.Status.Active || x.Status == Core.Core.Entity.Enum.Status.Updated)).OrderByDescending(x => x.CreatedDate).ToList();

        public void RejectOrder(Guid id)
        {
            Order order = GetById(id);
            order.IsConfirmed = false;
            order.Status = Core.Core.Entity.Enum.Status.Deleted;
            Update(order);
        }
    }
}
