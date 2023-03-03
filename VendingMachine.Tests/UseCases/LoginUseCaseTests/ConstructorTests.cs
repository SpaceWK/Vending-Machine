using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;

        private readonly LoginUseCase loginUseCase;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();

            loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);
        }

        [Fact]
        public void WhenInitializingTheUseCase_NameIsSet()
        {
            Assert.Equal("login", loginUseCase.Name);
        }

        [Fact]
        public void WhenInitializingTheUseCase_DescriptionIsSet()
        {
            Assert.Equal("Get access to administration section.", loginUseCase.Description);
        }

        [Fact]
        public void HavingNullAuthentificationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LoginUseCase(null, loginView.Object);
            }
            );
        }

        [Fact]
        public void HavingNullLoginView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LoginUseCase(authenticationService.Object, null);
            }
            );
        }
    }
}
