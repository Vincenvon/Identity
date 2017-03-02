using Microsoft.AspNet.Identity;
using Identity.Manager;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Identity.Entities;

namespace Identity.Context
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext():base("name=IdentityDb") {}
        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            string roleName1 = "Admin";
            string roleName2 = "User";
            string userName = "Admin";
            string password = "mypassword";
            string email = "vincenvon@gmail.com";

            if (!roleMgr.RoleExists(roleName1)&& !roleMgr.RoleExists(roleName2))
            {
                roleMgr.Create(new AppRole(roleName1));
                roleMgr.Create(new AppRole(roleName2));
            }

            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email },password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName1)&& !userMgr.IsInRole(user.Id, roleName2))
            {
                userMgr.AddToRole(user.Id, roleName1);
                userMgr.AddToRole(user.Id, roleName2);
            }
        }
    }
}
