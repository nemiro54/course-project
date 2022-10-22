namespace CollectionApp.Models;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
}