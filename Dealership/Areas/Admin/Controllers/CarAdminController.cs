﻿using Dealership.Core.Contracts;
using Dealership.Core.Models.Car;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dealership.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarAdminController : Controller
    {
        private readonly ICarService _carService;

        public CarAdminController(ICarService carService)
        {
            _carService = carService;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AllCarsForEvaluation()
        {
            var models = await _carService.GetAllCarsAsync();
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsCar(int id)
        {
            if (await _carService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

           var carForDetails = await _carService.DetailsCarAsync(id);

            return View(carForDetails);
        }
        [HttpGet]

        public IActionResult Add()
        {
            var userId = GetUserId();
            var model = new CarViewModel
            {
                UserId = userId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                await _carService.AddCarAsync(carViewModel);
                return RedirectToAction("AllSales", "AnnouncementAdmin");
            }

            return View(carViewModel);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
