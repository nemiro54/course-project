using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.Controllers;

public class SearchController : Controller
{
    private readonly ApplicationDbContext _context;

    public SearchController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult Index(string searchStr)
    {
        List<Item> items;
        List<MyCollection> collections;

        if (!string.IsNullOrEmpty(searchStr))
        {
            items = _context.Items
                .Where(p => p.SearchVector.Matches(searchStr))
                .ToList();
            collections = _context.MyCollections
                .Where(p => p.SearchVector.Matches(searchStr))
                .ToList();
        }
        else
        {
            items = _context.Items.ToList();
            collections = _context.MyCollections.ToList();
        }
        
        ViewBag.Items = items;
        ViewBag.Collections = collections;

        return View();
    }
}