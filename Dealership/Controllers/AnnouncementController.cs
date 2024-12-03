using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    public class AnnouncementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
