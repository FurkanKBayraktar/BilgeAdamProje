using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.UI.Attributes
{
    public class RoleAttribute : AuthorizeAttribute
    {
        private AppUserService _appUserService;
        private string[] _roles;

        public RoleAttribute(params string[] roles)
        {
            _appUserService = new AppUserService();
            _roles = new string[roles.Length];
            Array.Copy(roles, _roles, roles.Length);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            AppUser currentUser = _appUserService.GetByDefault(x => x.UserName == HttpContext.Current.User.Identity.Name);
            if (currentUser != null)
            {
                foreach (var item in _roles)
                {
                    if (currentUser.Role.ToString().Trim().ToLower() == item.Trim().ToLower())
                    {
                        return true;
                    }
                }
            }

            HttpContext.Current.Response.Redirect("~/Account/Login");
            return false;
        }


    }
}