using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xaloon.Areas.Data
{
    public enum Gender
    {
        Male,
        Female
    }
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Gender Gender { get; set; }

        [NotMapped]
        public string RoleId { get; set; }

        [NotMapped]
        public string Role { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? RoleList { get; set; }
    }
}
