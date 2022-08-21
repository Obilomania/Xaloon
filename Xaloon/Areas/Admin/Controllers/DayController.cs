using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xaloon.Areas.Admin.Models;
using Xaloon.Repository.IRepository;

namespace Xaloon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DayController : Controller
    {
        private readonly IDayRepository _context;

        public DayController(IDayRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Day> days = await _context.GetAllDays();
            return View(days);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0) return NotFound();
            Day day = await _context.GetDayById(id);
            return View(day);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Day day)
        {
            if (ModelState.IsValid)
            {
                _context.Add(day);
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(day);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Day day = await _context.GetDayById(id);
            if (day == null)
            {
                return NotFound();
            }
            return View(day);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Day day)
        {
            if (ModelState.IsValid)
            {
                _context.Update(day);
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(day);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Day day = await _context.GetDayById(id);
            if (day == null)
            {
                return NotFound();
            }
            return View(day);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Day days = await _context.GetDayById(id);
            if (days == null )
            {
                return NotFound();
            }
            _context.Delete(days);
            _context.Save();
            return RedirectToAction("Index");
        }
    }
}
