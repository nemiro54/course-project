using System.ComponentModel.DataAnnotations;
using CollectionApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionApp.ViewModels;

public class ItemCreateViewModel
{
    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }

    public string[] SelectedTags { get; set; } = Array.Empty<string>();
}