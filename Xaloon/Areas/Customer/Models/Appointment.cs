using System.ComponentModel.DataAnnotations;
using Xaloon.Areas.Admin.Models;
using Xaloon.Areas.Data;

namespace Xaloon.Areas.Customer.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser Booker { get; set; }
        public int? ApplicationUserId { get; set; }

        [Required]
        public Title Title { get; set; }
        public int TitleId { get; set; }

        [Required]
        public Day Day { get; set; }
        public int DayId { get; set; }

        [Required]
        public Time Time { get; set; }
        public int TimeId { get; set; }

        [Required]
        public string? ExtraMessage { get; set; }
    }
}
