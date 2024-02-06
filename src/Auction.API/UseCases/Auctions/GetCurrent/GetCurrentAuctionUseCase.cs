using Microsoft.EntityFrameworkCore;

namespace Auction.API.UseCases.Auctions.GetCurrent;

using Entities;
using Repositories;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new AuctionDbContext();

        var today = new DateTime(2024, 01, 25);
        
        return repository
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}