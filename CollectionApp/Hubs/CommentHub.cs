using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.Hubs;

[Authorize]
public class CommentHub : Hub
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _context;
    
    public CommentHub(UserManager<User> userManager, SignInManager<User> signInManager,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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
}