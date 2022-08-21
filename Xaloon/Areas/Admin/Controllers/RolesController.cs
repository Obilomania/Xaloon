using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Xaloon.Areas.Data;

namespace Xaloon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Upsert(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                var roleFromDb = _context.Roles.FirstOrDefault(r => r.Id == id);
                return View(roleFromDb);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(IdentityRole roleObj)
        {
            if (await _roleManager.RoleExistsAsync(roleObj.Name))
            {
                //error
                return RedirectToAction(nameof(Index));
            }
            if (string.IsNullOrEmpty(roleObj.Id))
            {
                //create
                await _roleManager.CreateAsync(new IdentityRole() { Name = roleObj.Name });
            }
            else
            {
                //update
                var objRoleFromDb = _context.Roles.FirstOrDefault(u => u.Id == roleObj.Id);
                if (objRoleFromDb == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                objRoleFromDb.Name = roleObj.Name;
                objRoleFromDb.NormalizedName = roleObj.Name.ToUpper();
                var result = await _roleManager.UpdateAsync(objRoleFromDb);
            }
            return RedirectToAction(nameof(Index));

        }

        //DELETE ROLE CONTROLLER
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var objFromDb = _context.Roles.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var userRolesForThisRole = _context.UserRoles.Where(u => u.RoleId == id).Count();
            if (userRolesForThisRole > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            await _roleManager.DeleteAsync(objFromDb);
            return RedirectToAction(nameof(Index));

        }
    }
}
