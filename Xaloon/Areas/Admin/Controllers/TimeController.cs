using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Xaloon.Areas.Admin.Models;
using Xaloon.Repository.IRepository;

namespace Xaloon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TimeController : Controller
    {
        private readonly ITimeRepository _context;

        public TimeController(ITimeRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Time> times = await _context.GetAllTime();
            return View(times);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0) return NotFound();
            Time time = await _context.GetDayById(id);
            return View(time);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Time time)
        {
            if (ModelState.IsValid)
            {
                _context.Add(time);
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(time);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Time time = await _context.GetDayById(id);
            if (time == null)
            {
                return NotFound();
            }
            return View(time);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Time time)
        {
            if (ModelState.IsValid)
            {
                _context.Update(time);
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(time);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Time time = await _context.GetDayById(id);
            if (time == null)
            {
                return NotFound();
            }
            return View(time);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Time times = await _context.GetDayById(id);
            if (times == null)
            {
                return NotFound();
            }
            _context.Delete(times);
            _context.Save();
            return RedirectToAction("Index");
        }
    }
}
