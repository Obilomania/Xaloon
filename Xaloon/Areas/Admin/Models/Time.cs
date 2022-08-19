using System.ComponentModel.DataAnnotations;

namespace Xaloon.Areas.Admin.Models
{
    public class Time
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Time")]
        public string SetTime { get; set; }
    }
}
