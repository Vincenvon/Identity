using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Entities
{
    public class AppRole: IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}
