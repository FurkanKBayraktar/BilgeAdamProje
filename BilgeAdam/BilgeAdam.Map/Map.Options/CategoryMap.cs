using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class CategoryMap : CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(category => category.Name).HasMaxLength(90).IsOptional();
            Property(category => category.Description).HasMaxLength(255).IsOptional();

            HasMany(category => category.Products)
                .WithRequired(product => product.Category)
                .HasForeignKey(product => product.CategoryID)
                .WillCascadeOnDelete(false);
            
        }
    }
}
