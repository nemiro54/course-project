using CollectionApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

[Authorize(Roles = "Admin")]
public class UsersController : Controller
{
    private readonly UserManager<User> _userManager;
    
    public UsersController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
 
    public IActionResult Index() => View(_userManager.Users.ToList());
}