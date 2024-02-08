namespace Auction.API.Interfaces;
using Entities;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}