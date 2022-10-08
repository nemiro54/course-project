using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace CollectionApp.Models;

public class MyCollection
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Theme { get; set; }
    
    public string UserId { get; set; }
    public User UserOwner { get; set; }
    
    public List<Item> Items { get; set; }
}