using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Abstract;

namespace BilgeAdam.Service.Service.Concrete
{
    public class OrderDetailService:BaseService<OrderDetail>
    {
        public List<OrderDetail> GetDetailsByOrderID(Guid id) => GetDefault(od => od.OrderID == id);
    }
}
