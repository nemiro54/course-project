using Microsoft.AspNetCore.Identity;

namespace CollectionApp.Models;

public class User : IdentityUser
{
    public List<CollectionItems> CollectionsItems { get; set; }
}