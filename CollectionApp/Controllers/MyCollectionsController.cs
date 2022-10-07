using CollectionApp.Data;
using CollectionApp.Models;
using CollectionApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

[Authorize]
public class MyCollectionsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _context;

    public MyCollectionsController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }
    
    public async Task<ActionResult> Index(string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        ViewBag.User = user;
        return View(user);
    }

    public async Task<IActionResult> Create(string userId)
    {
        ViewBag.Id = userId;
        var user = await _userManager.FindByIdAsync(userId);
        return View(user);
    }

    public async Task<IActionResult> Delete(string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        return View(user);
    }
}