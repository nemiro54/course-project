using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

public class ItemsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _context;

    public ItemsController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
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
}