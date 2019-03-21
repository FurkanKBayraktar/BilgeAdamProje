using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class StoreMap:CoreMap<Store>
    {
        public StoreMap()
        {
            ToTable("dbo.Stores");
            Property(store => store.Name).IsOptional();
            Property(store => store.Address).IsOptional();
            Property(store => store.Phone).IsOptional();
            Property(store => store.Email).IsOptional();

            HasMany(store => store.AppUsers)
                .WithRequired(appUser => appUser.Store)
                .HasForeignKey(appUser => appUser.StoreID)
                .WillCascadeOnDelete(false);

        }
    }
}
