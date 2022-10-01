using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CollectionApp.Models;

public class User : IdentityUser
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public Role Role { get; set; }
}