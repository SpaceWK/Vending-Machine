using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        
        private readonly LogoutUseCase logoutUseCase;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();

            logoutUseCase = new LogoutUseCase(authenticationService.Object);
        }

        [Fact]
        public void WhenInitializingTheUseCase_NameIsSet()
        {
            Assert.Equal("logout", logoutUseCase.Name);
        }

        [Fact]
        public void WhenInitializingTheUseCase_DescriptionIsSet()
        {
            Assert.Equal("Restrict access to administration section.", logoutUseCase.Description);
        }

        [Fact]
        public void HavingNullAuthentificationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LogoutUseCase(null);
            }
            );
        }
    }
}
