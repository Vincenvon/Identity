using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Models
{
    public class ProfileViewEditModel
    {

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Password { get; set; }

        public ProfileViewEditModel() { }

        public ProfileViewEditModel(IdentityUser user) {
            this.Email = user.Email;
            this.Id = user.Id;
            this.Name = user.UserName;
        }

    }
}