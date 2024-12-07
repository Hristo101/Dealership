using Dealership.Core.Contracts;
using Dealership.Core.Models;
using Dealership.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dealership.Controllers
{
    public class QueryController : Controller
    {
        private readonly IQueryService queryService;

        public QueryController(IQueryService _queryService)
        {
            queryService = _queryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddQuery(int announcementId)
        {

            var model = new QueryListViewModel
            {
                AnnouncementId = announcementId, 
                AdminResponse = string.Empty,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuery(QueryListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await queryService.AddQueryAsync(model.Message, model.AnnouncementId, userId);

                TempData["SuccessMessage"] = "Вашето запитване беше изпратено успешно!";

                return RedirectToAction("Details", "Announcement", new { id = model.AnnouncementId });
            }

            return View(model); 
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
 }

