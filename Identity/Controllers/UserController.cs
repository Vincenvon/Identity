using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web;
using Identity.Models;
using Microsoft.AspNet.Identity.Owin;
using Identity.Manager;

namespace Identity.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        // GET: User
        public ActionResult Prof()//View of profile of the user
        {
            var userName = HttpContext.GetOwinContext().Request.User.Identity.Name;
            var user = UserManager.FindByName(userName);
            return View(new ProfileViewEditModel(user));
        }

        [HttpGet]
        public ActionResult Edit()//Edit of profile of the user
        {
            var userName = HttpContext.GetOwinContext().Request.User.Identity.Name;
            var user = UserManager.FindByName(userName);
            return View(new ProfileViewEditModel(user));
        }

        [HttpPost]
        public ActionResult Edit(ProfileViewEditModel model)//Edit of profile of the user
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(model.Id);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;
                    UserManager.Update(user);//Password change dont work!!!!!!!!
                    return Redirect("/User/Prof");
                }
                else {
                    ModelState.AddModelError("Name", "Невозможно изменить данные нового пользователя");
                    return View("Edit", model);
                }
            }
            else {
                return View("Edit", model);
            }
        }
    }
}