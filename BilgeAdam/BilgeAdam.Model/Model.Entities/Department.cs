using BilgeAdam.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Model.Model.Entities
{
    public class Department:CoreEntity
    {
        public Department()
        {
            {
                AppUsers = new HashSet<AppUser>();
            }
        }
        public string DepartmentName { get; set; }

        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
    
}
