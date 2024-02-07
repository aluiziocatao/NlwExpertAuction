using NlwExpertAuction.API.Contracts;
using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly NlwExpertAuctionDbContext _dbContext;

    public OfferRepository(NlwExpertAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
