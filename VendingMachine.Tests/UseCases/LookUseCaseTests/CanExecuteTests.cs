using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LookUseCaseTests
{
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IShelfView> lookView;

        private readonly LookUseCase lookUseCase;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            lookView = new Mock<IShelfView>();

            lookUseCase = new LookUseCase(authenticationService.Object, productRepository.Object, lookView.Object);
        }

        [Fact]
        public void HavingNoAdminLooggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            Assert.True(lookUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLooggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            Assert.False(lookUseCase.CanExecute);
        }
    }
}
