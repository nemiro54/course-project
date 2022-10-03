using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace CollectionApp.Models;

public class Collection
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Theme { get; set; }
    public string UrlImg { get; set; }
    public User Owner { get; set; }
    public List<Collection> Items { get; set; }
}