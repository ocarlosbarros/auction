using Auction.API.Entities;

namespace Auction.API.Interfaces;

public interface IOfferRepository
{
    void Add(Offer offer);
}