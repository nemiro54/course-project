using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers;

public class CollectionsItemsController : Controller
{
    public async Task<IActionResult> Index(string[] selectedUsers)
    {
        return View();
    }
    
    public async Task<IActionResult> Delete(string[] selectedUsers)
    {
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Create(string[] selectedUsers)
    {
        return RedirectToAction("Index");
    }
}