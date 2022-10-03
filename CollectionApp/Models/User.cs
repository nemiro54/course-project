using Microsoft.AspNetCore.Identity;

namespace CollectionApp.Models;

public class User : IdentityUser
{
    public List<Collection> Collections { get; set; }
}