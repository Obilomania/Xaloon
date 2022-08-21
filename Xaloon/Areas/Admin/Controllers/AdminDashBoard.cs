using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Xaloon.Areas.Customer.Models;
using Xaloon.Areas.Data;
using Xaloon.Repository.IRepository;

namespace Xaloon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminDashBoard : Controller
    {
        private readonly IAdminDashboardRepository _iapp;
        private readonly IDayRepository _ayRepository;
        private readonly ITitleRepository _trep;
        private readonly ApplicationDbContext _db;

        private readonly ITimeRepository _timeRepository;
        public AdminDashBoard(IAdminDashboardRepository iapp, IDayRepository ayRepository, ITimeRepository timeRepository, ITitleRepository trep, ApplicationDbContext db)
        {
            _iapp = iapp;
            _ayRepository = ayRepository;
            _timeRepository = timeRepository;
            _trep = trep;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Appointment> appointment = await  _iapp.GetAllAppointments();
            return View(appointment);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }

            Appointment appointment = await _iapp.GetById(id);
            return View(appointment);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }

            Appointment appointment = await _iapp.GetById(id);
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
        public async Task<IActionResult> Edit(int? id, [Bind("Id,ApplicationUserId,TitleId,DayId,TimeId,ExtraMessage,BookedOn,IsApproved,Approved")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _iapp.Update(appointment);
                    _iapp.Save();
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
            Appointment appointment = await _iapp.GetById(id);
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
            var appointment = await _iapp.GetById(id);
            if (appointment != null)
            {
                _iapp.Delete(appointment);
            }

            _iapp.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return (_db.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
