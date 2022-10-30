using System.ComponentModel.DataAnnotations;
using CollectionApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionApp.ViewModels;

public class ItemCreateViewModel
{
    [Required]
    public string Name { get; set; }
    
    public List<Tag> SelectedTags { get; set; }
}