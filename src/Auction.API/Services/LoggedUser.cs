using Auction.API.Repositories;
using Auction.API.Entities;

namespace Auction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public LoggedUser(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }
    
    public User GetUser()
    {
        var repository = new AuctionDbContext();
        
        var token = TokenOnRequest();
        var email = FromBase64String(token);
        
        return repository.Users.First(user => user.Email.Equals(email));
    }
    
    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        
        //"authentication format: Bearer token"
        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}