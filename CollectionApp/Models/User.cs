using Microsoft.AspNetCore.Identity;

namespace CollectionApp.Models;

public class User : IdentityUser
{
    public List<MyCollection> MyCollections { get; set; }
    public List<Comment> Comments { get; set; }
}