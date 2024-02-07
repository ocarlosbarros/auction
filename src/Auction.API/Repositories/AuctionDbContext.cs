using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories;

using Entities;
public class AuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=/home/ocarlosbarros/Repos/databases/auctionDb.db");
    }
}