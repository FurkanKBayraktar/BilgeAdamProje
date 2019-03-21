using BilgeAdam.Core.Core.Map;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Map.Map.Options
{
    public class DepartmentMap:CoreMap<Department>
    {
        public DepartmentMap()
        {
            ToTable("dbo.Departments");
            Property(department => department.DepartmentName).IsOptional();

            HasMany(department => department.AppUsers)
               .WithRequired(appUser => appUser.Department)
               .HasForeignKey(appUser => appUser.DepartmentID)
               .WillCascadeOnDelete(false);
        }
    }
}
