using NlwExpertAuction.API.Contracts;
using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository)
    {
        _repository = repository;
    }

    public Auction? Execute()
    {
        return _repository.GetCurrent();
    }
}
