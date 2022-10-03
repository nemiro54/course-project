using CollectionApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

[Authorize]
public class PersonalAccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public PersonalAccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<ActionResult> Index(string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        return View(user);
    }
}