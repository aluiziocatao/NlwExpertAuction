using Microsoft.EntityFrameworkCore;
using NlwExpertAuction.API.Contracts;
using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{

    private readonly NlwExpertAuctionDbContext _dbContext;
    public AuctionRepository(NlwExpertAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}