using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Identity.Models;
using Identity.Entities;
using Identity.Manager;
using System.Web;
using Microsoft.Owin.Security;
using System.Security.Claims;


namespace Identity.Controllers
{
    public class RegistrController : Controller
    {
        [HttpGet]
        public ActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registr(RegistViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    user = UserManager.FindByName(model.Name);
                    UserManager.AddToRole(user.Id, "User");
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    return Redirect("/User/Prof");
                }
           
            }
            return View(model);
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}