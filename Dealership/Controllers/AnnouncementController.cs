using Dealership.Core.Contracts;
using Dealership.Core.Models.Announcement;
using Dealership.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService announcementService;
        private const int PageSize = 6;
        public AnnouncementController(IAnnouncementService _announcementService)
        {
            this.announcementService = _announcementService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All(int page = 1, int pageSize = 6)
        {
            var announcements = await announcementService.AllAnnouncementAsync(page, pageSize);

            var totalAnnouncements = await announcementService.GetTotalAnnouncementCountAsync();

            var totalPages = (int)Math.Ceiling(totalAnnouncements / (double)pageSize);

            var model = new AnnouncementListViewModel
            {
                Announcements = announcements,
                CurrentPage = page,
                TotalPages = totalPages
            };

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

            if (model == null)
            {
                int statusCode = 404;
                return RedirectToAction("Error", "Home",new {statusCode}); 
            }

            return View(model);
        }
        public async Task<IActionResult> Search(string make, string year, string engine, string transmission, string color, string sortBy, int page = 1, int pageSize = 6)
        {
            var filteredAnnouncements = await announcementService.GetFilteredAnnouncements(make, year, engine, transmission, color, sortBy, page, pageSize);

            var totalAnnouncements = await announcementService.GetTotalAnnouncementCountAsync();

            var totalPages = (int)Math.Ceiling(totalAnnouncements / (double)pageSize);


            return View(filteredAnnouncements);
        }
    }
}

