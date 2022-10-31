using Microsoft.Build.Framework;

namespace CollectionApp.ViewModels;

public class ItemEditViewModel
{
    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }

    public string[] SelectedTags { get; set; } = Array.Empty<string>();
}