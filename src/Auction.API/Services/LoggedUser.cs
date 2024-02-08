using Auction.API.Repositories;
using Auction.API.Entities;
using Auction.API.Interfaces;

namespace Auction.API.Services;

public class LoggedUser 
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;
    
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAccessor = httpContext;
        _repository = repository;
    }
    
    public User GetUser()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return _repository.GetUserByEmail(email);
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