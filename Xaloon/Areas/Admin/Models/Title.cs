using System.ComponentModel.DataAnnotations;

namespace Xaloon.Areas.Admin.Models
{
    public class Title
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Bookingitle { get; set; }
    }
}
