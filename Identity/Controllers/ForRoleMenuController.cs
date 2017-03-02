using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class ForRoleMenuController : Controller
    {
        
        [HttpGet]
        [Authorize(Roles ="User,Admin")]
        public ActionResult GetRole()
        {
            var user = HttpContext.GetOwinContext().Request.User.IsInRole("Admin");
            if (user)
            {
                return View("Admin");
            }
            else
            {
                return View("User");
            }
        }
    }
}