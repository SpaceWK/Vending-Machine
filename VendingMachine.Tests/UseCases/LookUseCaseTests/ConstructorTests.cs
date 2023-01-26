using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LookUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IShelfView> lookView;

        private readonly LookUseCase lookUseCase;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            lookView = new Mock<IShelfView>();

            lookUseCase = new LookUseCase(authenticationService.Object, productRepository.Object, lookView.Object);
        }

        [Fact]
        public void WhenInitializingTheUseCase_NameIsSet()
        {
            Assert.Equal("look", lookUseCase.Name);
        }

        [Fact]
        public void WhenInitializingTheUseCase_DescriptionIsSet()
        {
            Assert.Equal("Now you can see the shelf.", lookUseCase.Description);
        }

        [Fact]
        public void HavingNullAuthentificationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LookUseCase(null, productRepository.Object, lookView.Object);
            }
            );
        }

        [Fact]
        public void HavingNullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LookUseCase(authenticationService.Object, null, lookView.Object);
            }
            );
        }

        [Fact]
        public void HavingNullShelfView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LookUseCase(authenticationService.Object, productRepository.Object, null);
            }
            );
        }
    }
}
