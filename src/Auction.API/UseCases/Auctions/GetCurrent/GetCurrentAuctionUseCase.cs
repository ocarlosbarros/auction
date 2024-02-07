using Auction.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.UseCases.Auctions.GetCurrent;

using Entities;
using Repositories;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;
    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;
    public Auction? Execute() => _repository.GetCurrent(); 
}