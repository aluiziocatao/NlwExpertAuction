using Bogus;
using FluentAssertions;
using Moq;
using NlwExpertAuction.API.Contracts;
using NlwExpertAuction.API.Entities;
using NlwExpertAuction.API.Enums;
using NlwExpertAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        //AAA - ARRANGE - ACT - ASSERT
        //ARRANGE - Instancia o que precisa
        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, faker => faker.Random.Number(1, 700))
            .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
            .RuleFor(auction => auction.Starts, faker => faker.Date.Past())
            .RuleFor(auction => auction.Ends, faker => faker.Date.Future())
            .RuleFor(auction => auction.Items, (faker, auction) => new List<Item>
            {
                new Item
                {
                    Id = faker.Random.Number(1, 1000),                    
                    Name = faker.Commerce.ProductName(),
                    Brand = faker.Commerce.Department(),
                    BasePrice = faker.Random.Decimal(),
                    Condition = faker.PickRandom<Condition>(),
                    AuctionId = auction.Id,
                }
            }).Generate();
        {

        };

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);
        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        //ACT - Executa o que precisa
        var auction = useCase.Execute();

        //ASSERT - Verifica se o resultado que retornou é o esperado
        //Assert.NotNull(auction); // Do .NET
        auction.Should().NotBeNull(); // Do pacote FluentAssertions
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);
    }
}
