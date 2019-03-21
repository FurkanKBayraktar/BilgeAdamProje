using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(product => product.ProductCode).IsOptional();
            Property(product => product.Name).IsOptional();
            Property(product => product.UnitsInStock).IsOptional();
            Property(product => product.Price).IsOptional();
            Property(product => product.QuantityPerUnit).IsOptional();
            Property(product => product.ImagePath).IsOptional();
            Property(product => product.Barcode).IsOptional();

            HasMany(product => product.OrderDetails)
                .WithRequired(orderDetail => orderDetail.Product)
                .HasForeignKey(orderDetail => orderDetail.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
