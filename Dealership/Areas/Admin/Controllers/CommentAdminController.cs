using Dealership.Core.Contracts;
using Dealership.Core.Models.Comments;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentAdminController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;


        public CommentAdminController(ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var comments = await _commentService.GetAllCommentsAsync();

            var currentUser = await _userManager.GetUserAsync(User);

            var commentViewModels = comments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                UserName = c.User.UserName ?? string.Empty,
                Content = c.Content,
                CreatedAt = c.CreatedAt,
                Grade = c.Grade,

                CanEdit = c.UserId == currentUser?.Id,
                CanDelete = c.UserId == currentUser?.Id,
                CanDetails = true
            }).ToList();

            return View(commentViewModels);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var model = await _commentService.GetConfirmDeleteViewModelAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDeletePost(int id)
        {
            var result = await _commentService.DeleteCommentAsync(id);

            if (result)
            {
                return RedirectToAction("All");
            }

            return NotFound();
        }
    }
}
