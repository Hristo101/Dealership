using Dealership.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService announcementService;

        public AnnouncementController(IAnnouncementService _announcementService)
        {
            this.announcementService = _announcementService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await announcementService.AllAnnouncementAsync();

            return View(model);
        }
    }
}
