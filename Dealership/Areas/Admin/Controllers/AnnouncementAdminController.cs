using Dealership.Core.Contracts;
using Dealership.Core.Models.Announcement;
using Dealership.Core.Services;
using Dealership.Extensions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dealership.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementAdminController : Controller
    {
        private readonly IAnnouncementService announcementService;
        private readonly ICarService carService;
        private const int PageSize = 6;
        public AnnouncementAdminController(IAnnouncementService _announcementService, ICarService _carService)
        {
            this.announcementService = _announcementService;
            this.carService = _carService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AllSales(int page = 1, int pageSize = 6)
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
        public async Task<IActionResult> Edit(int id)
        {
            if (await announcementService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await announcementService.GetAnnouncementForEditAsync(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditAnnouncementViewModel model,int id)
        {
            if (await announcementService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await announcementService.EditAsync(id, model);

            return RedirectToAction(nameof(AllSales));
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
        public async Task<IActionResult> ConfrimDelete(int id)
        {
            if (await announcementService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await announcementService.GetAnnouncementForDeleteAsync(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await announcementService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await announcementService.RemoveAsync(id);

            return RedirectToAction(nameof(AllSales));
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var cars = await carService.GetAllCarsAsync(); 

            var model = new AddAnnouncementViewModel
            {
                Cars = cars.ToList(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddAnnouncementViewModel model)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                var cars = await carService.GetAllCarsAsync();
                model.Cars = cars.ToList();
                return View(model);
            }

            await announcementService.AddAsync(model);

            return RedirectToAction(nameof(AllSales));
        }
        [HttpGet]
        public async Task<IActionResult> Evaluation(int id)
        {
            if (await carService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await announcementService.GetModelForAnnouncment(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Evaluation(AnnouncementEvaluationViewModel model,int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await carService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            await announcementService.EvaluationAsync(id, model);

            return RedirectToAction("AllCarsForEvaluation","CarAdmin");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
