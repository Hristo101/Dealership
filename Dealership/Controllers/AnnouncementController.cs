using Dealership.Core.Contracts;
using Dealership.Core.Services;
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
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await announcementService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await announcementService.DetailsAnnouncementAsync(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string make, string year, string engine, string transmission, string color, string sortBy)
        {
            var viewModel = await announcementService.GetFilteredAnnouncements(make, year, engine, transmission, color, sortBy);
            return View(viewModel);
        }
    }
}

