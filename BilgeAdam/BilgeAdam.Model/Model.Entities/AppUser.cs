using BilgeAdam.Core.Core.Entity;
using BilgeAdam.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Model.Model.Entities
{

    public class AppUser:CoreEntity

    {
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImagePath { get; set; }

        public Guid DepartmentID { get; set; }

        public Guid StoreID { get; set; }

        public virtual Department Department { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public string FullName
        {
            get
            {
                return Name + " " + LastName;
            }

        }

    }
}
