using CollectionApp.Data;
using CollectionApp.Models;
using CollectionApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

public class ItemsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _context;

    public ItemsController(UserManager<User> userManager, SignInManager<User> signInManager,
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
            ViewBag.User = collection.UserOwner;
        }
        var items = _context.Items.Where(p => p.MyCollection.Id.Equals(collectionId)).ToList();
        return View(items);
    }

    public IActionResult Create(string collectionId)
    {
        ViewBag.Id = collectionId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ItemCreateViewModel model, string collectionId)
    {
        if (ModelState.IsValid)
        {
            var item = new Item { Name = model.Name };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Items", new { collectionId });
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(Guid[] selectedItems)
    {
        var collectionId = (await _context.Items.FindAsync(selectedItems[0]))!.MyCollection.Id;
        foreach (var id in selectedItems)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index", "Items", new { collectionId });
    }
}