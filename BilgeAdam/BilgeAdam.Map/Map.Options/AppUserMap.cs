using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Core.Core.Map;

namespace BilgeAdam.Map.Map.Options
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Ignore(user => user.FullName);


            Property(user => user.Gender).IsOptional();
            Property(user => user.Role).IsOptional();
            Property(user => user.Address).HasMaxLength(255).IsOptional();
            Property(user => user.IdentityNumber).HasMaxLength(11).IsOptional();
            Property(user => user.Name).IsOptional();
            Property(user => user.LastName).IsOptional();
            Property(user => user.Salary).IsOptional();
            Property(user => user.Email).IsOptional();
            Property(user => user.Phone).IsOptional();
            Property(user => user.District).IsOptional();
            Property(user => user.City).IsOptional();
            Property(user => user.Country).IsOptional();
            Property(user => user.Birthdate).HasColumnType("datetime2").IsOptional();
            Property(user => user.ImagePath).IsOptional();


            Property(user => user.UserName).IsRequired();
            Property(user => user.Password).IsRequired();

            HasMany(appUser => appUser.Orders)
                .WithRequired(order => order.AppUser)
                .HasForeignKey(order => order.AppUserID)
                .WillCascadeOnDelete(false);

        }
    }
}
