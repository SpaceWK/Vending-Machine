﻿using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IBuyView> buyView;

        private readonly BuyUseCase buyUseCase;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();

            buyUseCase = new BuyUseCase(authenticationService.Object, productRepository.Object, buyView.Object);
        }

        [Fact]
        public void HavingTheNameOfTheBuyUseCase_WhenInstancieted_ReturnsTheName()
        {
            Assert.Equal(buyUseCase.Name, "buy");
        }

        [Fact]
        public void HavingTheDescriptionOfTheBuyUseCase_WhenInstancieted_ReturnsTheDescription()
        {
            Assert.Equal(buyUseCase.Description, "Now you can buy a product");
        }

        [Fact]
        public void HavingNullAuthentificationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(null, productRepository.Object, buyView.Object);
            }
            );
        }

        [Fact]
        public void HavingNullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(authenticationService.Object, null, buyView.Object);
            }
            );
        }

        [Fact]
        public void HavingNullBuyView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(authenticationService.Object, productRepository.Object, null);
            }
            );
        }
    }
}
