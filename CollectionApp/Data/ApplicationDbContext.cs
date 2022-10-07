using CollectionApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<MyCollection> MyCollections { get; set; }
    public DbSet<Item> Items { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}