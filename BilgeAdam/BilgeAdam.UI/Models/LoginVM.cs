using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeAdam.UI.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola giriniz.")]
        [DisplayName("Parola")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool isPersistent { get; set; }
    }
}