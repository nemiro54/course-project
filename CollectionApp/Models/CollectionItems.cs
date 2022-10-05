using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace CollectionApp.Models;

public class CollectionItems
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Theme { get; set; }
    public string UrlImg { get; set; }
}