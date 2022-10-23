using System.Security.Claims;
using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

[Authorize(Roles = "Admin")]
public class UsersController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _context;

    public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }
 
    public IActionResult Index() => View(_userManager.Users.ToList());
    
    [HttpPost]
    public async Task<IActionResult> Delete(string[] selectedUsersId)
    {
        foreach (var userId in selectedUsersId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                await _userManager.DeleteAsync(user);
            }
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Block(string[] selectedUsersId)
    {
        foreach (var userId in selectedUsersId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            user.IsBlock = true;
            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> UnBlock(string[] selectedUsersId)
    {
        foreach (var userId in selectedUsersId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            user.IsBlock = false;
            await _userManager.UpdateAsync(user);
        }
        return RedirectToAction("Index");
    }
}