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
        private readonly IDayRepository _ayRepository;
        private readonly ITimeRepository _timeRepository;
        private readonly ITitleRepository _trep;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppointmentsController(IAppointmentRepository context, ApplicationDbContext db, IDayRepository ayRepository, ITimeRepository timeRepository, ITitleRepository trep, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _db = db;
            _ayRepository = ayRepository;
            _timeRepository = timeRepository;
            _trep = trep;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Appointment> appointments = await _context.GetAllAppointments();
            return View(appointments);
        }

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
            ViewData["DayId"] = new SelectList(_ayRepository.GetAllDays().Result, "Id", "SetDay");
            ViewData["TimeId"] = new SelectList(_timeRepository.GetAllTime().Result, "Id", "SetTime");
            ViewData["TitleId"] = new SelectList(_trep.GetAllTitles().Result, "Id", "Bookingitle");
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
            ViewData["DayId"] = new SelectList(_ayRepository.GetAllDays().Result, "Id", "SetDay", appointment.DayId);
            ViewData["TimeId"] = new SelectList(_timeRepository.GetAllTime().Result, "Id", "SetTime", appointment.TimeId);
            ViewData["TitleId"] = new SelectList(_trep.GetAllTitles().Result, "Id", "Bookingitle", appointment.TitleId);
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
            ViewData["DayId"] = new SelectList(_ayRepository.GetAllDays().Result, "Id", "SetDay", appointment.DayId);
            ViewData["TimeId"] = new SelectList(_timeRepository.GetAllTime().Result, "Id", "SetTime", appointment.TimeId);
            ViewData["TitleId"] = new SelectList(_trep.GetAllTitles().Result, "Id", "Bookingitle", appointment.TitleId);
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
            ViewData["DayId"] = new SelectList(_ayRepository.GetAllDays().Result, "Id", "SetDay", appointment.DayId);
            ViewData["TimeId"] = new SelectList(_timeRepository.GetAllTime().Result, "Id", "SetTime", appointment.TimeId);
            ViewData["TitleId"] = new SelectList(_trep.GetAllTitles().Result, "Id", "Bookingitle", appointment.TitleId);
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
