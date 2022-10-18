using NpgsqlTypes;

namespace CollectionApp.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string message { get; set; }
    public NpgsqlTsVector SearchVector { get; set; }
    public string ItemId { get; set; }
}