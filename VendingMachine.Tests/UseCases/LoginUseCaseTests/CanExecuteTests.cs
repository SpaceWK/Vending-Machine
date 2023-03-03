using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;

        private readonly LoginUseCase loginUseCase;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();

            loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);
        }

        [Fact]
        public void HavingNoAdminLooggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            Assert.True(loginUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLooggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            Assert.False(loginUseCase.CanExecute);
        }
    }
}
