﻿using Bogus;
using FluentAssertions;
using Moq;
using NlwExpertAuction.API.Comunication.Requests;
using NlwExpertAuction.API.Contracts;
using NlwExpertAuction.API.Entities;
using NlwExpertAuction.API.Services;
using NlwExpertAuction.API.UseCases.Offers.CreateOffer;
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
        //AAA - ARRANGE - ACT - ASSERT
        //ARRANGE - Instancia o que precisa
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, faker => faker.Random.Decimal(1, 700))
            .Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //ACT - Executa o que precisa
        var act = () => useCase.Execute(itemId, request);

        //ASSERT - Verifica se o resultado que retornou é o esperado
        act.Should().NotThrow();

    }
}
