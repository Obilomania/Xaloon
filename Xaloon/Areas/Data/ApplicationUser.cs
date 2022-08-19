using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
    }
}
