using Microsoft.EntityFrameworkCore;
using NlwExpertAuction.API.Entities;
using NlwExpertAuction.API.Repositories;

namespace NlwExpertAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new NlwExpertAuctionDbContext();

        var today = DateTime.Now;

        return repository
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
