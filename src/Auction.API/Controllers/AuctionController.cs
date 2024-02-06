using Microsoft.AspNetCore.Mvc;
using Auction.API.UseCases.Auctions.GetCurrent;

namespace Auction.API.Controllers;

using Entities;

[Route("[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentAuctionUseCase();
        
        var response = useCase.Execute();
        
        if (response is null)
            return NoContent();
        
        return Ok(response);
    }
}
