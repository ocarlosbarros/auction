using Auction.API.Communication.Requests;
using Auction.API.Entities;
using Auction.API.Enums;
using Auction.API.Interfaces;
using Auction.API.Services;
using Auction.API.UseCases.Auctions.GetCurrent;
using Auction.API.UseCases.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //Arrange
        var requestCreateOfferFake = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, fake => fake.Random.Decimal(1, 100000)).Generate();
        
        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        
        loggedUser.Setup(i => i.GetUser()).Returns(new User());
        
        var useCase = new CreateOfferUseCase(loggedUser.Object,offerRepository.Object);
        
        //Act
        var act = () => useCase.Execute(itemId, requestCreateOfferFake);
        
        //Assertion
        act.Should().NotThrow();

    }
}