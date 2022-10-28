using CollectionApp.Data;
using CollectionApp.Models;
using CollectionApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.Controllers;

[Authorize]
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
    [AllowAnonymous]
    public async Task<ActionResult> Index(Guid itemId)
    {
        var item = await _context.Items.FindAsync(itemId);
        var countLikes = _context.Likes
            .Count(l => l.ItemId.Equals(itemId));
        var comments = _context.Comments
            .Include(c => c.User)
            .Where(c => c.Item.Id.Equals(itemId))
            .OrderByDescending(c => c.DateTime)
            .ToList();
        ViewBag.Comments = comments;
        ViewBag.CountLikes = countLikes;
        return View(item);
    }

    public IActionResult Create(string collectionId)
    {
        ViewBag.Id = collectionId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ItemCreateViewModel model, Guid collectionId)
    {
        if (ModelState.IsValid)
        {
            var item = new Item
            {
                Name = model.Name,
                Tags = model.Tags,
                MyCollection = (await _context.MyCollections.FindAsync(collectionId))!,
                MyCollectionId = collectionId
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "MyCollections", new { collectionId });
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(Guid itemId)
    {
        var item = _context.Items.Find(itemId);
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Item model, Guid itemId)
    {
        var item = await _context.Items.FindAsync(itemId);
        if (item == null)
        {
            return NotFound();
        }
        item.Name = model.Name;
        var collectionId = item.MyCollectionId;
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "MyCollections", new { collectionId });
    }

    public async Task<IActionResult> Delete(Guid[] selectedItems)
    {
        var collectionId = (await _context.Items.FindAsync(selectedItems[0]))!.MyCollectionId;
        foreach (var id in selectedItems)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index", "MyCollections", new { collectionId });
    }
}