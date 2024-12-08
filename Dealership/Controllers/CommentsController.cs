﻿using Dealership.Core.Contracts;
using Dealership.Core.Models.Comments;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class CommentsController : Controller
{
    private readonly ICommentService _commentService;
    private readonly UserManager<ApplicationUser> _userManager;

    private static int _idCounter = 0;

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