using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

public class PersonalAccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;
    
    public PersonalAccountController(UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult> Index(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var collections = _context.MyCollections.Where(c => c.UserId.Equals(user.Id)).ToList();
        ViewBag.User = user;
        return View(collections);
    }
}