using BilgeAdam.Core.Core.Entity;
using System.Collections.Generic;

namespace BilgeAdam.Model.Model.Entities
{
    public class Customer : CoreEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string Tax { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
