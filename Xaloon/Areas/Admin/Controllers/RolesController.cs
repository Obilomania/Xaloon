using Microsoft.AspNetCore.Mvc;

namespace Xaloon.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
