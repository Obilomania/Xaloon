using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Customer.Models;
using Xaloon.Areas.Customer.Models.ViewModel;
using Xaloon.Repository.IRepository;

namespace Xaloon.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IDashboardRepository dashboardRepository, IHttpContextAccessor httpContextAccessor, IAppointmentRepository appointmentRepository)
        {
            _dashboardRepository = dashboardRepository;
            _httpContextAccessor = httpContextAccessor;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Appointment> appointments = await _appointmentRepository.GetAllAppointments();
            return View(appointments);

        }
    }
}
