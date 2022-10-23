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
    private readonly ApplicationDbContext _context;

    public MyCollectionsController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult> Index(Guid collectionId)
    {
        var collection = await _context.MyCollections.FindAsync(collectionId);
        var user = await _context.Users.FindAsync(collection.UserId);
        ViewBag.User = user;
        ViewBag.MyCollection = collection;
        var items = _context.Items.Where(p => p.MyCollection.Id.Equals(collectionId)).ToList();
        return View(items);
    }

    [HttpGet]
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
            var user = await _context.Users.FindAsync(userId);
            var collection = new MyCollection
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
    
    [HttpGet]
    public IActionResult Edit(Guid collectionId)
    {
        var collection = _context.MyCollections.Find(collectionId);
        return View(collection);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(MyCollection model, Guid collectionId)
    {
        var collection = await _context.MyCollections.FindAsync(collectionId);
        if (collection != null)
        {
            collection.Name = model.Name;
            collection.Theme = model.Theme;
            collection.Summary = model.Summary;
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "PersonalAccount", new { collection.UserId });
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