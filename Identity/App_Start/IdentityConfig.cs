using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Identity.Context;
using Identity.Manager;

namespace Identity.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        { 
            app.CreatePerOwinContext<AppIdentityDbContext>(()=>AppIdentityDbContext.Create());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}