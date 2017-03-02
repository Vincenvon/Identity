using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Identity.Manager;
using Identity.Entities;

namespace Identity.Infrastructure
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, AppUser user)
        {
            AppUserManager mgr = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            var rolesTask = mgr.GetRolesAsync(user.Id);
            var result = rolesTask.Result;
            return new MvcHtmlString(string.Join(",",result));
        }
    }
}