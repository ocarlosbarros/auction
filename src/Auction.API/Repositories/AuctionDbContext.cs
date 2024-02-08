using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories;

using Entities;
public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options){}
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}