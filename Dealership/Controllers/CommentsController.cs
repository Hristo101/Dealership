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
        var user = await _userManager.GetUserAsync(User);
        model.Username = user?.UserName;

        if (ModelState.IsValid)
        {
            var comment = new Comment
            {
                Id = model.Id,
                User = user,
                Content = model.Content,
                Grade = model.Grade,
                UserId = user?.Id,
                CreatedAt = DateTime.Now
            };

            await _commentService.AddCommentAsync(comment);

            return RedirectToAction("AllComments");
        }

        return View(model);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        var model = new EditCommentViewModel
        {
            Id = comment.Id,
            Content = comment.Content,
            Grade = comment.Grade
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCommentViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _commentService.UpdateCommentAsync(model);
                return RedirectToAction(nameof(AllComments));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        return View(model);
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
    [ActionName("ConfirmDelete")]
    public async Task<IActionResult> ConfirmDeletePost(int id)
    {
        var result = await _commentService.DeleteCommentAsync(id);

        if (result)
        {
            return RedirectToAction("AllComments");
        }

        return NotFound();
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }
}