namespace CollectionApp.Models;

public class Like
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid ItemId { get; set; }
}