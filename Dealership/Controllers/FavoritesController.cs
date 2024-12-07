using Dealership.Core.Contracts;
using Dealership.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dealership.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoriteService _favoriteService;
        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            string userId = User.Identity.Name;
            var favoriteAnnouncements = await _favoriteService.GetFavoritesAsync(userId);

            var model = new FavoriteViewModel
            {
                Announcements = favoriteAnnouncements
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            await _favoriteService.AddToFavoritesAsync(userId, id);

            TempData["SuccessMessage"] = "Обявата беше добавена към вашите любими!";
            return RedirectToAction("Details", "Announcement", new { id });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
