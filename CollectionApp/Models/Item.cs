namespace CollectionApp.Models;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    // public string MyCollectionId { get; set; }
    public MyCollection MyCollection { get; set; }
}