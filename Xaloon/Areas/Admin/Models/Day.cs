using System.ComponentModel.DataAnnotations;

namespace Xaloon.Areas.Admin.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Day")]
        public string SetDay { get; set; }
    }
}
