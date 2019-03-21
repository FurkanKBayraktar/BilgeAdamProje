using BilgeAdam.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Model.Model.Entities
{
    public class Supplier:CoreEntity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public string SupplierCode { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string Tax { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
