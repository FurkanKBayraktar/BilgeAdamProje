using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class SupplierMap:CoreMap<Supplier>
    {
        public SupplierMap()
        {

            ToTable("dbo.Suppliers");
            Property(supplier => supplier.Name).IsOptional();
            Property(supplier => supplier.SupplierCode).IsOptional();
            Property(supplier => supplier.ContactName).IsOptional();
            Property(supplier => supplier.ContactTitle).IsOptional();
            Property(supplier => supplier.Address).IsOptional();
            Property(supplier => supplier.Tax).IsOptional();
            Property(supplier => supplier.TaxNumber).IsOptional();
            Property(supplier => supplier.Phone).IsOptional();
            Property(supplier => supplier.Email).IsOptional();
            Property(supplier => supplier.District).IsOptional();
            Property(supplier => supplier.City).IsOptional();
            Property(supplier => supplier.Country).IsOptional();

            HasMany(supplier => supplier.Products)
                .WithRequired(product => product.Supplier)
                .HasForeignKey(product => product.SupplierID)
                .WillCascadeOnDelete(false);

        }
    }
}
