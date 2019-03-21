using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Areas.Admin.Models.DTO
{
    public class DepartmentVM
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}