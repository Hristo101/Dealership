using Dealership.Core.Contracts;
using Dealership.Core.Models.Query;
using Dealership.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dealership.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QueryAdminController : Controller
    {
        private readonly IQueryService queryService;

        public QueryAdminController(IQueryService _queryService)
        {
            queryService = _queryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllQueries()
        {
            var models = await queryService.ShowAllQueriesWithoutAnswer();

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> GiveAnswer(int id)
        {
            if (await queryService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await queryService.AddAnswer(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GiveAnswer(QueryAnswerViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await queryService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            await queryService.AddAnswerAsync(id, model);

            return RedirectToAction(nameof(ShowAllQueries));
        }
    }
}
