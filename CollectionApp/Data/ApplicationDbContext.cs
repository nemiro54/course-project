using CollectionApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XLocalizer.DB.Models;

namespace CollectionApp.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<User> Users { get; set; }
    public DbSet<MyCollection> MyCollections { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<XDbCulture> XDbCultures { get; set; }
    public DbSet<XDbResource> XDbResources { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<XDbResource>()
            .HasKey(r => r.ID);

        builder.Entity<XDbResource>()
            .HasIndex(r => new { r.CultureID, r.Key })
            .IsUnique();
        builder.Entity<XDbResource>()
            .HasOne(t => t.Culture)
            .WithMany(t => t.Translations as IEnumerable<XDbResource>)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Item>()
            .HasGeneratedTsVectorColumn(
                p => p.SearchVector,
                "english",  // Text search config
                p => new { p.Name })  // Included properties
            .HasIndex(p => p.SearchVector)
            .HasMethod("GIN"); // Index method on the search vector (GIN or GIST)
        
        builder.Entity<MyCollection>()
            .HasGeneratedTsVectorColumn(
                p => p.SearchVector,
                "english",  // Text search config
                p => new { p.Name, p.Summary, p.Theme })  // Included properties
            .HasIndex(p => p.SearchVector)
            .HasMethod("GIN"); // Index method on the search vector (GIN or GIST)
        
        builder.Entity<Comment>()
            .HasGeneratedTsVectorColumn(
                p => p.SearchVector,
                "english",  // Text search config
                p => new { p.Message })  // Included properties
            .HasIndex(p => p.SearchVector)
            .HasMethod("GIN"); // Index method on the search vector (GIN or GIST)

        builder.SeedCultures();
        builder.SeedResourceData();

        base.OnModelCreating(builder);
    }
}