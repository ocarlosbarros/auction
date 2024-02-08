using Auction.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories.DataAccess;

using Entities;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionDbContext _dbContext;

    public AuctionRepository(AuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = new DateTime(2024, 01, 25);
        
        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);        
    }
    
}