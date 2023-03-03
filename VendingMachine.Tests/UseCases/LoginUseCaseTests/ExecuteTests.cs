using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;

        private readonly LoginUseCase loginUseCase;

        public ExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();

            loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);
        }

        [Fact]
        public void HavingALoginUseCaseInstance_WhenExecuted_TheUserIsAskedForPassword()
        {
            loginUseCase.Execute();

            loginView.Verify(x => x.AskForPassword(), Times.Once());
        }

        [Fact]
        public void HavingALoginUseCaseInstance_WhenExecuted_TheUserIsLoggedIn()
        {
            loginView
                .Setup(x => x.AskForPassword())
                .Returns("parola");

            loginUseCase.Execute();

            authenticationService.Verify(x => x.Login("parola"), Times.Once());
        }
    }
}
