using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace CollectionApp.Hubs;

public class LikeHub : Hub
{
    private readonly ApplicationDbContext _context;

    public LikeHub(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Like(string userId, Guid itemId)
    {
        var isLiked = _context.Likes
            .Any(l => l.ItemId.Equals(itemId) && l.UserId.Equals(userId));
        Like like;
        if (isLiked)
        {
            like = await _context.Likes.FindAsync(userId, itemId);
            _context.Likes.Remove(like);
        }
        else
        {
            like = new Like
            {
                UserId = userId,
                ItemId = itemId
            };
            _context.Likes.Add(like);
        }

        await _context.SaveChangesAsync();
        var countLikes = _context.Likes
            .Count(l => l.ItemId.Equals(itemId));
        await Clients.All.SendAsync("Like", countLikes);
    }
}