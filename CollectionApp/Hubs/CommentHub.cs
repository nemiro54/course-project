using CollectionApp.Data;
using CollectionApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace CollectionApp.Hubs;

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
    
    public async Task Send(string message, string userName)
    {
        await this.Clients.All.SendAsync("Send", message, userName);
    }
}