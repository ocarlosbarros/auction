using Auction.API.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

public class OfferController : AuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute]int itemId, [FromBody] RequestCreateOfferJson request)
    {
        return Created();
    }
}