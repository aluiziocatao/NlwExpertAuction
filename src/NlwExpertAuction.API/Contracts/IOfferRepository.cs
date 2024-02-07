using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
