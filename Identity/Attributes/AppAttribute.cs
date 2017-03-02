using System.ComponentModel.DataAnnotations;
using Identity.Models;
using System.Linq;

namespace Identity.Attributes
{
    public class AppAttribute: ValidationAttribute
    {
        public AppAttribute() { }
        public override bool IsValid(object value) {
            ChanModel item = (ChanModel)value;
            if (item.Roles.Count(x => x.IsSelected) > 0)
            {
                if ((item.Roles.Any(x => x.Role == "Admin") && item.Roles.Count(x => x.IsSelected) == item.Roles.Count())||(item.Roles.Any(x => x.Role == "Admin")))
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}