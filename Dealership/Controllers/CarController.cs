using Dealership.Core.Contracts;
using Dealership.Core.Models;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dealership.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult AddCar()
        {
            var userId = GetUserId();
            var model = new CarViewModel
            {
                UserId = userId 
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                await _carService.AddCarAsync(carViewModel);
                return RedirectToAction("Index", "Home"); 
            }

            return View(carViewModel);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
