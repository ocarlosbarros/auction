using Auction.API.Communication.Requests;
using Auction.API.Entities;
using Auction.API.Interfaces;
using Auction.API.Repositories;
using Auction.API.Services;

namespace Auction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    private readonly IOfferRepository _repository;

    public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }

    public int Execute(int itemId,RequestCreateOfferJson request)
    {
        var user = _loggedUser.GetUser();
        
        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };
        
        _repository.Add(offer);
        
        return offer.Id;
    }
}