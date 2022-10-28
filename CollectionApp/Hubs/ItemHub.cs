using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.Hubs;

[Authorize]
public class ItemHub : Hub
{
    private readonly ApplicationDbContext _context;
    
    public ItemHub(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Send(string message, string userId, Guid itemId)
    {
        var user = await _context.Users.FindAsync(userId);
        var item = await _context.Items.FindAsync(itemId);
        var comment = new Comment
        {
            Message = message,
            DateTime = DateTime.UtcNow,
            User = user,
            Item = item
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        await Clients.All.SendAsync("Send", message, user.UserName, comment.DateTime.ToLocalTime());
    }
    
    public async Task Like(string userId, Guid itemId)
    {
        var isLiked = _context.Likes
            .Any(l => l.ItemId.Equals(itemId) && l.UserId.Equals(userId));
        Like like;
        if (isLiked)
        {
            like = _context.Likes.First(l => l.ItemId.Equals(itemId) && l.UserId.Equals(userId));
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