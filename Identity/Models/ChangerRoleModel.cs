using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using Identity.Attributes;


namespace Identity.Models
{
    public class ChanderRoleModel
    {
        private string role;
        private bool isSelected;
        public ChanderRoleModel()
        {
            this.role = string.Empty;
            isSelected = false;
        }

        public string Role {
            get { return role; }
            set { role = value; }
        }
        public bool IsSelected {
            get { return isSelected;}
            set {isSelected = value;}
        }
    }
    [App]
    public class ChanModel {
        private string  userId;
        private ChanderRoleModel[] roles;
        public ChanModel(IQueryable<IdentityRole> all, IdentityUser us) {
            this.userId = us.Id;
            roles = IdentityArray.CheckSelectedRoles(all, us.Roles);
        }

        public ChanModel() { }
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public ChanderRoleModel[] Roles
        {
            get { return roles; }
            set { roles = value; }}
    }

    public static class IdentityArray
    {
        public static ChanderRoleModel[] CheckSelectedRoles(IQueryable<IdentityRole> all, ICollection<IdentityUserRole> rolOfUsr)
        {
            List<ChanderRoleModel> resultAsList = new List<ChanderRoleModel>();
            foreach (var item in all) {
                if (rolOfUsr.Any(x => x.RoleId == item.Id))
                {
                    resultAsList.Add(new ChanderRoleModel() { Role = item.Name, IsSelected = true });
                }
                else {
                    resultAsList.Add(new ChanderRoleModel() { Role = item.Name, IsSelected = false });
                }
            }
            return resultAsList.ToArray();
        }
    }
}