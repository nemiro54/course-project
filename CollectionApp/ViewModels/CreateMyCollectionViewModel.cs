using System.ComponentModel.DataAnnotations;

namespace CollectionApp.ViewModels;

public class CreateMyCollectionViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Summary { get; set; }
    [Required]
    public string Theme { get; set; }
    [Required]
    public string UrlImg { get; set; }
}