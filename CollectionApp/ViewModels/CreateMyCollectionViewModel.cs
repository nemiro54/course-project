using System.ComponentModel.DataAnnotations;

namespace CollectionApp.ViewModels;

public class CreateMyCollectionViewModel
{
    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Summary")]
    public string Summary { get; set; }
    [Required]
    [Display(Name = "Theme")]
    public string Theme { get; set; }
}