using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
