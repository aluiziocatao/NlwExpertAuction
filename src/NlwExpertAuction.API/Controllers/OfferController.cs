using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NlwExpertAuction.API.Comunication.Requests;
using NlwExpertAuction.API.Filters;
using NlwExpertAuction.API.UseCases.Offers.CreateOffer;

namespace NlwExpertAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : NlwExpertAuctionControllerBase
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
            [FromRoute] int itemId,
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
