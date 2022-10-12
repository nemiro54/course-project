using Microsoft.EntityFrameworkCore;
using XLocalizer.DB.Models;

namespace CollectionApp.Data;

public static class XLocalizerDbExtensions
{
    public static void SeedCultures(this ModelBuilder modelBuilder)
    {
        // Seed initial data for localization stores
        modelBuilder.Entity<XDbCulture>().HasData(
            new XDbCulture { IsActive = true, IsDefault = true, ID = "en", EnglishName = "English" },
            new XDbCulture { IsActive = true, IsDefault = false, ID = "be", EnglishName = "Belarusian" },
            new XDbCulture { IsActive = true, IsDefault = false, ID = "pl", EnglishName = "Polish" }
        );
    }

    public static void SeedResourceData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<XDbResource>().HasData(
            new XDbResource { ID = 1, Key = "Welcome", Value = "Вітаем", CultureID = "be", IsActive = true, Comment = "Created by XLocalizer" }
        );
    }
}