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
    public async Task<ActionResult> Index(Guid collectionId)
    {
        var collection = await _context.MyCollections.FindAsync(collectionId);
        if (collection != null)
        {
            ViewBag.MyCollection = collection;
        }
        var items = _context.Items.Where(p => p.MyCollection.Id.Equals(collectionId)).ToList();
        return View(items);
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
            // var user = await _userManager.FindByIdAsync(userId);
            var user = await _context.Users.FindAsync(userId);
            MyCollection collection = new MyCollection
            {
                Name = model.Name,
                Theme = model.Theme,
                Summary = model.Summary,
                UserOwner = user!,
                UserId = user!.Id
            };
            _context.MyCollections.Add(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PersonalAccount", new { userId });
        }
        
        return View(model);
    }

    public async Task<IActionResult> Delete(Guid[] selectedCollections)
    {
        var userId = (await _context.MyCollections.FindAsync(selectedCollections[0]))!.UserId;
        foreach (var id in selectedCollections)
        {
            var collection = await _context.MyCollections.FindAsync(id);
            if (collection != null)
            {
                _context.MyCollections.Remove(collection);
            }
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index", "PersonalAccount", new { userId });
    }
}