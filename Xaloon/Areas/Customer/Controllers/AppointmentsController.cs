using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Customer.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;

namespace Xaloon.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IAppointmentRepository _context;

        public AppointmentsController(IAppointmentRepository context, ApplicationDbContext db)
        {
            _context = context;
            _db = db;
        }

        // GET: Customer/Appointments
        public async Task<IActionResult> Index()
        {
            IEnumerable<Appointment> appointments = await _context.GetAllAppointments();
            return View(appointments);
        }

        // GET: Customer/Appointments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }

            Appointment appointment = await _context.GetById(id);
            return View(appointment);
        }

        public IActionResult Create()
        {
            ViewData["DayId"] = new SelectList(_db.Days, "Id", "SetDay");
            ViewData["TimeId"] = new SelectList(_db.Times, "Id", "SetTime");
            ViewData["TitleId"] = new SelectList(_db.Titles, "Id", "Bookingitle");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,TitleId,DayId,TimeId,ExtraMessage,BookedOn,IsApproved")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DayId"] = new SelectList(_db.Days, "Id", "SetDay", appointment.DayId);
            ViewData["TimeId"] = new SelectList(_db.Times, "Id", "SetTime", appointment.TimeId);
            ViewData["TitleId"] = new SelectList(_db.Titles, "Id", "Bookingitle", appointment.TitleId);
            return View(appointment);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }

            Appointment  appointment = await _context.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DayId"] = new SelectList(_db.Days, "Id", "SetDay", appointment.DayId);
            ViewData["TimeId"] = new SelectList(_db.Times, "Id", "SetTime", appointment.TimeId);
            ViewData["TitleId"] = new SelectList(_db.Titles, "Id", "Bookingitle", appointment.TitleId);
            return View(appointment);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,TitleId,DayId,TimeId,ExtraMessage,BookedOn,IsApproved")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DayId"] = new SelectList(_db.Days, "Id", "SetDay", appointment.DayId);
            ViewData["TimeId"] = new SelectList(_db.Times, "Id", "SetTime", appointment.TimeId);
            ViewData["TitleId"] = new SelectList(_db.Titles, "Id", "Bookingitle", appointment.TitleId);
            return View(appointment);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }
            Appointment appointment = await _context.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Appointments'  is null.");
            }
            var appointment = await _context.GetById(id);
            if (appointment != null)
            {
                _context.Delete(appointment);
            }
            
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return (_db.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
