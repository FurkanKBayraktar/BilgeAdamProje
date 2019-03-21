using BilgeAdam.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Member.Models.DTO
{
    public class StoreVM
    {
        [Required]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}