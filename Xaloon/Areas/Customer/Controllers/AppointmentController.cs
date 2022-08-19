using Microsoft.AspNetCore.Mvc;
using Xaloon.Areas.Admin.Models;
using Xaloon.Areas.Customer.Models;
using Xaloon.Repository.IRepository;

namespace Xaloon.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _context;

        public AppointmentController(IAppointmentRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Appointment> appointments = await _context.GetAll();
            return View(appointments);
        }


        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0) return NotFound();
            Appointment appointment = await _context.GetById(id);
            return View(appointment);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
    }
}
