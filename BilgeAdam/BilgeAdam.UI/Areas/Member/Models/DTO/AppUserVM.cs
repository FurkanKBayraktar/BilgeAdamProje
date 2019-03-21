using BilgeAdam.Core.Core.Entity.Enum;
using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Member.Models.DTO
{
    public class AppUserVM
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        [EmailAddress(ErrorMessage = "Hatalı E-Posta Formatı!")]
        public string Email { get; set; }
        [Phone(ErrorMessage ="Hatalı Telefon Formatı!")]
        public string Phone { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImagePath { get; set; }

        public Guid DepartmentID { get; set; }
        
        public Guid StoreID { get; set; }

    }
}