using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Member.Models.DTO
{
    public class CategoryVM
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}