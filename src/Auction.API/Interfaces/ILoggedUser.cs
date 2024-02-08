using Auction.API.Entities;

namespace Auction.API.Interfaces;

public interface ILoggedUser
{
    User GetUser();
}