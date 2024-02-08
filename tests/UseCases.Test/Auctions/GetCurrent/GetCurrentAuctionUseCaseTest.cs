using Auction.API.Enums;
using Auction.API.Interfaces;
using Auction.API.UseCases.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;
namespace UseCases.Test.Auctions.GetCurrent;
using Auction.API.Entities;

public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        //Arrange
        var fakeAuction = new Faker<Auction>()
            .RuleFor(auction => auction.Id, fake => fake.Random.Number(1, 10))
            .RuleFor(auction => auction.Name, fake => fake.Name.FullName())
            .RuleFor(auction => auction.Starts, fake => fake.Date.Soon())
            .RuleFor(auction => auction.Ends, fake => fake.Date.Future())
            .RuleFor(auction => auction.Items, (fake, auction) => new List<Item>
            {
                new Item
                {
                    Id = fake.Random.Number(1, 100),
                    Name = fake.Commerce.ProductName(),
                    Brand = fake.Company.CompanyName(),
                    BasePrice = fake.Random.Decimal(1, 1000000),
                    Condition = fake.PickRandom<ConditionEnum>(),
                    AuctionId = auction.Id
                    
                }
            }).Generate();
        
        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(fakeAuction);
        var useCase = new GetCurrentAuctionUseCase(mock.Object);
        
        //Act
        var auction = useCase.Execute();
        
        //Assertion
        auction.Should().NotBeNull();
        auction.Id.Should().Be(fakeAuction.Id);
        auction.Name.Should().Be(fakeAuction.Name);
    }
}