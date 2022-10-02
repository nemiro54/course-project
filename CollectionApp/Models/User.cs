using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CollectionApp.Models;

public class User : IdentityUser
{
    public User() : base()
    {
    }
}