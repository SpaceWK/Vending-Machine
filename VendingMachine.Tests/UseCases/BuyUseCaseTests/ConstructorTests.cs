using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.DataAccess;
using VendingMachine.Business.Payment;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentService> paymentService;

        private readonly BuyUseCase buyUseCase;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            paymentService = new Mock<IPaymentService>();

            buyUseCase = new BuyUseCase(authenticationService.Object, productRepository.Object, buyView.Object, paymentService.Object);
        }

        [Fact]
        public void WhenInitializingTheUseCase_NameIsSet()
        {
            Assert.Equal("buy", buyUseCase.Name);
        }

        [Fact]
        public void WhenInitializingTheUseCase_DescriptionIsSet()
        {
            Assert.Equal("Now you can buy a product.", buyUseCase.Description);
        }

        [Fact]
        public void HavingNullAuthentificationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(null, productRepository.Object, buyView.Object, paymentService.Object);
            }
            );
        }

        [Fact]
        public void HavingNullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(authenticationService.Object, null, buyView.Object, paymentService.Object);
            }
            );
        }

        [Fact]
        public void HavingNullBuyView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(authenticationService.Object, productRepository.Object, null, paymentService.Object);
            }
            );
        }

        [Fact]
        public void HavingNullPaymentService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(authenticationService.Object, productRepository.Object, buyView.Object, null);
            }
            );
        }
    }
}
