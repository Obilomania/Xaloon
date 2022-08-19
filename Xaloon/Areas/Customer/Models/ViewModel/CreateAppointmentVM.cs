using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xaloon.Areas.Admin.Models;

namespace Xaloon.Areas.Customer.Models.ViewModel
{
    public class CreateAppointmentVM
    {
        //public int Id { get; set; }
        //public string ApplicationUserId { get; set; }
        //public Title Title { get; set; }
        //public Day Day { get; set; }
        //public Time Time { get; set; }
        //public string ExtraMessage { get; set; }
        //public DateTime BookedOn { get; set; }
        //public bool IsApproved { get; set; }
        public Appointment appointment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TitleList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DayList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TimeList { get; set; }
    }
}
