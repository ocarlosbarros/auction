using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCurrentAuction()
    {
        return Ok("Bem Vindo, NLW Expert!");
    }
}