using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;

        private readonly LogoutUseCase logoutUseCase;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();

            logoutUseCase = new LogoutUseCase(authenticationService.Object);
        }

        [Fact]
        public void HavingNoAdminLooggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            Assert.False(logoutUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLooggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            Assert.True(logoutUseCase.CanExecute);
        }
    }
}
