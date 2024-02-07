using Microsoft.EntityFrameworkCore;
using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.Repositories;

public class NlwExpertAuctionDbContext : DbContext
{
    public NlwExpertAuctionDbContext(DbContextOptions options) : base(options)
    {        
    }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }

}
