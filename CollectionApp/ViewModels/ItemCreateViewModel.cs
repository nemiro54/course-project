using System.ComponentModel.DataAnnotations;
using CollectionApp.Models;

namespace CollectionApp.ViewModels;

public class ItemCreateViewModel
{
    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Display(Name = "Tags")]
    public List<Tag> Tags { get; set; }
}