using NpgsqlTypes;

namespace CollectionApp.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public DateTime DateTime { get; set; }
    public NpgsqlTsVector SearchVector { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
}