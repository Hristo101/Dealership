using Dealership.Core.Contracts;
using Dealership.Core.Models.Comments;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Dealership.Infrastructure.Common.Constants.DataConstant;

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
        var currentUser = await _userManager.GetUserAsync(User);

        var comments = await _commentService.GetAllCommentsAsync();

        return View(comments);
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
            model.Username = user?.UserName; 

            await _commentService.AddCommentAsync(model,GetUserId());

            return RedirectToAction("AllComments");
        }

        return View(model); 
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Невалиден идентификатор на коментар.");
        }

        var model = await _commentService.GetCommentByIdAsync(id);

        var currentUser = await _userManager.GetUserAsync(User);

        var hasPermission = await _commentService.UserHasPermissionToEditOrDeleteComment(currentUser.Id, model.Id);

        if (!hasPermission)
        {

            return Unauthorized();
        }

        if (!ModelState.IsValid || model.IsInvalid)
        {
            Response.StatusCode = 500;
            return RedirectToAction("Error", "Home");
        }


        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCommentViewModel model)
    {

            if (ModelState.IsValid)
            {
                await _commentService.UpdateCommentAsync(model);
                return RedirectToAction(nameof(AllComments));
            }

            return View(model);
        
    }
    [HttpGet]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        var model = await _commentService.GetConfirmDeleteViewModelAsync(id);

        var currentUser = await _userManager.GetUserAsync(User);

        var hasPermission = await _commentService.UserHasPermissionToEditOrDeleteComment(currentUser.Id, model.Id);

        if (!hasPermission)
        {

            return Unauthorized();
        }
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
            return RedirectToAction("AllComments");
        }
        return BadRequest();
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }
}