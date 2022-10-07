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

    public MyCollectionsController(UserManager<User> userManager, SignInManager<User> signInManager,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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

    public IActionResult Create(string userId)
    {
        ViewBag.Id = userId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMyCollectionViewModel model, string userId)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(userId);
            MyCollection collection = new MyCollection
            {
                Name = model.Name,
                Theme = model.Theme,
                Summary = model.Summary,
                UrlImg = model.UrlImg,
                UserOwner = user,
                UserId = user.Id
            };
            _context.MyCollections.Add(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "MyCollections", new { userId });
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        return View(user);
    }
}