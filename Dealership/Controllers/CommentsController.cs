using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AllComments()
        {
            return View();
        }
    }
}
