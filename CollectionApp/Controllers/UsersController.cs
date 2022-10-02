using CollectionApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    
    public UsersController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
 
    [Authorize(Roles = "Admin")]
    public IActionResult Index() => View(_userManager.Users.ToList());
}