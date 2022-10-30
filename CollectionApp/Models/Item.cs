using NpgsqlTypes;

namespace CollectionApp.Models;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public NpgsqlTsVector SearchVector { get; set; }
    public List<Comment> Comments { get; set; }
    public Guid MyCollectionId { get; set; }
    public MyCollection MyCollection { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();
}