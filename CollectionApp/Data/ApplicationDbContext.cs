using CollectionApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    private DbSet<CollectionItems> CollectionItems { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}