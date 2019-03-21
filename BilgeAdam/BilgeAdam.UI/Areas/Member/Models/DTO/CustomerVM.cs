using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Member.Models.DTO
{
    public class CustomerVM
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string CustomerCode { get; set; }
        [Required]
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string Tax { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}