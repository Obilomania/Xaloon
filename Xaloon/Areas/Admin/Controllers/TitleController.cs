using Microsoft.AspNetCore.Mvc;
using Xaloon.Areas.Admin.Models;
using Xaloon.Repository.IRepository;

namespace Xaloon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TitleController : Controller
    {
        private readonly ITitleRepository _context;

        public TitleController(ITitleRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Title> titles = await _context.GetAllDays();
            return View(titles);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0) return NotFound();
            Title title = await _context.GetDayById(id);
            return View(title);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Add(title);
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(title);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Title title = await _context.GetDayById(id);
            if (title == null)
            {
                return NotFound();
            }
            return View(title);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Update(title);
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(title);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Title title = await _context.GetDayById(id);
            if (title == null)
            {
                return NotFound();
            }
            return View(title);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Title titles = await _context.GetDayById(id);
            if (titles == null)
            {
                return NotFound();
            }
            _context.Delete(titles);
            _context.Save();
            return RedirectToAction("Index");
        }
    }
}
