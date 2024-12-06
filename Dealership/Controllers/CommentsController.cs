using Dealership.Core.Contracts;
using Dealership.Core.Models;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class CommentsController : Controller
{
    private readonly ICommentService _commentService;
    private readonly UserManager<ApplicationUser> _userManager;
    public CommentsController(ICommentService commentService, UserManager<ApplicationUser> userManager)
    {
        _commentService = commentService;
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> AllComments()
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

    [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCommentViewModel();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                model.Username = user?.UserName;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var comment = new Comment
                {
                    User = user,
                    Content = model.Content,
                    Grade = model.Grade,
                    UserId = GetUserId(), 
                    CreatedAt = DateTime.Now
                };

                await _commentService.AddCommentAsync(comment);

                return RedirectToAction("AllComments");
            }

            return View(model);
        }
    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }
}