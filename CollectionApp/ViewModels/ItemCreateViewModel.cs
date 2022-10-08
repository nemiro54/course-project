using System.ComponentModel.DataAnnotations;

namespace CollectionApp.ViewModels;

public class ItemCreateViewModel
{
    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }
}