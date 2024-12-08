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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
