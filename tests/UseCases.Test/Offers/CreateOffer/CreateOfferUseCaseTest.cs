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
    [Fact]
    public void Success()
    {
        //Arrange
        var requestCreateOfferFake = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, fake => fake.Random.Decimal(1, 100000)).Generate();
        
        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        
        loggedUser.Setup(i => i.GetUser()).Returns(new User());
        
        var useCase = new CreateOfferUseCase(loggedUser.Object,offerRepository.Object);
        
        //Act
        var act = () => useCase.Execute(0, requestCreateOfferFake);
        
        //Assertion
        act.Should().NotThrow();

    }
}