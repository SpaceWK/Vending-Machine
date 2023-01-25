using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        
        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
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
