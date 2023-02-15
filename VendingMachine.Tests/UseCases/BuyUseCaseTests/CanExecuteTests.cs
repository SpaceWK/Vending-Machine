using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IBuyView> buyView;

        private readonly BuyUseCase buyUseCase;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();

            buyUseCase = new BuyUseCase(authenticationService.Object, productRepository.Object, buyView.Object);
        }

        [Fact]
        public void HavingNoAdminLooggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            Assert.True(buyUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLooggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            Assert.False(buyUseCase.CanExecute);
        }
    }
}
