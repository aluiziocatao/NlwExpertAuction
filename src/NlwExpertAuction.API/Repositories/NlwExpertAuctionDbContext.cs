using Microsoft.EntityFrameworkCore;
using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.Repositories;

public class NlwExpertAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=D:\\Documentos\\Code\\NlwExpertAuction\\leilaoDbNLW.db");
    }
}
