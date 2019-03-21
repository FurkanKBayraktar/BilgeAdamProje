using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class CustomerMap:CoreMap<Customer>
    {
        public CustomerMap()
        {
            ToTable("dbo.Customers");
            Property(customer => customer.CustomerCode).IsOptional();
            Property(customer => customer.Name).IsOptional();
            Property(customer => customer.ContactName).IsOptional();
            Property(customer => customer.Address).IsOptional();
            Property(customer => customer.Tax).IsOptional();
            Property(customer => customer.TaxNumber).IsOptional();
            Property(customer => customer.Phone).IsOptional();
            Property(customer => customer.Email).IsOptional();
            Property(customer => customer.District).IsOptional();
            Property(customer => customer.City).IsOptional();
            Property(customer => customer.Country).IsOptional();


            HasMany(customer => customer.Orders)
                .WithRequired(order => order.Customer)
                .HasForeignKey(order => order.CustomerID)
                .WillCascadeOnDelete(false);
        }
    }
}
