using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Identity.Entities;
using Identity.Context;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;

namespace Identity.Manager
{
    public class AppUserManager: UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store): base(store)
        { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
           IOwinContext context)
        {
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
            return manager;
        }
    }
    
}
