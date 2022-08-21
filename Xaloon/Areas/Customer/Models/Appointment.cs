﻿using System.ComponentModel.DataAnnotations;
using Xaloon.Areas.Admin.Models;
using Xaloon.Areas.Data;

namespace Xaloon.Areas.Customer.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser? Booker { get; set; }



        [Display(Name ="Booking Title")]
        public int? TitleId { get; set; }
        public Title? Title { get; set; }



        [Display(Name = "Day")]
        public int? DayId { get; set; }
        public Day? Day { get; set; }



        [Display(Name = "Time")]
        public int? TimeId { get; set; }
        public Time? Time { get; set; }



        [Display(Name = "Extra Message")]
        public string? ExtraMessage { get; set; }



        [DataType(DataType.Date)]
        public DateTime BookedOn { get; set; } = DateTime.Now;



        [Display(Name = "Status")]
        public bool? IsApproved { get; set; }

        public bool Approved { get; set; }

    }
}
