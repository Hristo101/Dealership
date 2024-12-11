using Dealership.Core.Contracts;
using Dealership.Infrastructure.Data.Models;
using Dealership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dealership.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;
        public HomeController(ILogger<HomeController> logger, IHomeService _homeService)
        {
            _logger = logger;
            this.homeService = _homeService;
        }
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }


            return View();
        }
        public async Task<IActionResult> Index()
        {
            var cars = await homeService.GetCarsForHomePageAsync();
            return View(cars);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult HowWeWork()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
