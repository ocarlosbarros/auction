using Auction.API.Entities;

namespace Auction.API.Interfaces;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    public User GetUserByEmail(string email);
}