using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.DataAccess;
using VendingMachine.Business.Payment;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentService> paymentService;

        private readonly BuyUseCase buyUseCase;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            paymentService = new Mock<IPaymentService>();

            buyUseCase = new BuyUseCase(authenticationService.Object, productRepository.Object, buyView.Object, paymentService.Object);
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
