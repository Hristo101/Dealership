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
            string userId = GetUserId(); // Идентификатор на потребителя
            var favoriteAnnouncements = await _favoriteService.GetFavoritesAsync(userId);

            return View(favoriteAnnouncements);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            var alreadyAdded = await _favoriteService.IsFavoriteAsync(userId, id);

            if (alreadyAdded)
            {
                int statusCode = 404;
                TempData["ErrorMessage"] = "Тази обява вече е добавена в любими!";

                return RedirectToAction("Error", "Home", new { statusCode });
            }

            await _favoriteService.AddToFavoritesAsync(userId, id);

            TempData["SuccessMessage"] = "Обявата беше добавена към вашите любими!";
            return RedirectToAction("All");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int announcementId)
        {
            string userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            bool success = await _favoriteService.RemoveFromFavoritesAsync(userId, announcementId);

            if (success)
            {
                TempData["Message"] = "Обявата беше премахната от любимите!";
            }
            else
            {
                TempData["Message"] = "Не можахме да премахнем обявата.";
            }

            return RedirectToAction("All"); 
        }


        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
