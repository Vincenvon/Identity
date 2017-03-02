using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web;
using Identity.Models;
using Microsoft.AspNet.Identity.Owin;
using Identity.Manager;

namespace Identity.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
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

        [HttpGet]
        public PartialViewResult AllUsers()
        {
            var users = UserManager.Users;
            return PartialView(users);
        }

        [HttpGet]
        public ViewResult ChangeRole(string id) {
            var user = UserManager.FindById(id);
            ChanModel model = new ChanModel(RoleManager.Roles, user);
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeRole(ChanModel modelItem)//Must insert checking of number of roles
        {
            if (ModelState.IsValid)
            {
                foreach (var item in modelItem.Roles)
                {
                    if (item.IsSelected)
                    {
                        UserManager.AddToRole(modelItem.UserId, item.Role);
                    }
                    else UserManager.RemoveFromRole(modelItem.UserId, item.Role);
                }
                return Redirect("/Admin/AllUsers");
            }
            else {
                ModelState.AddModelError("", "Проверьте правильность заполнения ролей");
                return View("ChangeRole", modelItem);
            }
        }
    }
}