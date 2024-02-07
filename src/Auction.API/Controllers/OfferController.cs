using Auction.API.Communication.Requests;
using Auction.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;
[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : AuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute]int itemId, [FromBody] RequestCreateOfferJson request)
    {
        return Created();
    }
}