using Microsoft.AspNet.Identity;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Identity.Entities;
using Identity.Context;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;

namespace Identity.Manager
{
    public class AppRoleManager:RoleManager<AppRole>, IDisposable
    {
        public AppRoleManager(RoleStore<AppRole> store): base(store){ }
        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options,IOwinContext context)
        {
            return new AppRoleManager(new RoleStore<AppRole>(context.Get<AppIdentityDbContext>()));
        }
    }
}
