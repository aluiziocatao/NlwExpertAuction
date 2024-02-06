using Microsoft.AspNetCore.Mvc;
using NlwExpertAuction.API.Entities;
using NlwExpertAuction.API.UseCases.Auctions.GetCurrent;

namespace NlwExpertAuction.API.Controllers;

public class AuctionController : NlwExpertAuctionControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }
}