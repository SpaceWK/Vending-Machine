using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.DataAccess;
using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Models;
using VendingMachine.Business.Payment;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentService> paymentService;

        private readonly BuyUseCase buyUseCase;

        public ExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            paymentService = new Mock<IPaymentService>();

            buyUseCase = new BuyUseCase(authenticationService.Object, productRepository.Object, buyView.Object, paymentService.Object);
        }

        [Fact]
        public void HavingABuyUseViewInstance_WhenExecuted_ThenRequestAProduct()
        {
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {
                    Quantity = 1
                });

            buyUseCase.Execute();

            buyView.Verify(x => x.RequestProduct(), Times.Once);
        }

        [Fact]
        public void HavingABuyUseCaseInstance_WhenExecuted_ReturnsProductWithIntroducedId()
        {
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(3);

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {
                    Quantity = 1
                });

            buyUseCase.Execute();

            productRepository.Verify(x => x.GetByColumnId(3), Times.Once);
        }

        [Fact]
        public void HavingAProductRepositoryReturnNoProduct_WhenExecuted_ThrowsInvalidProductException()
        {
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(3);

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns((Product)null);

            Assert.Throws<InvalidProductException>(() =>
            {
                buyUseCase.Execute();
            }
            );
        }

        [Fact]
        public void NotHavingEnoughQuantityForAProduct_WhenExecuted_ThrowsInsufficientStockException()
        {
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(3);

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {
                    Quantity = 0
                });

            Assert.Throws<InsufficientStockException>(() =>
            {
                buyUseCase.Execute();
            }
            );
        }

        [Fact]
        public void HavingAPaymentServiceInstance_WhenExecuted_ThenExecuteThePaymentMethod()
        {
            buyView
                 .Setup(x => x.RequestProduct())
                 .Returns(3);

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {
                    Quantity = 1,
                    Price = 20
                });

            buyUseCase.Execute();

            paymentService.Verify(x => x.Execute(20), Times.Once);
        }

        [Fact]
        public void HavingABuyUseCaseInstance_WhenExecuted_DecrementTheQuantityOfTheSelectedProduct()
        {
            Product product = new Product() { Quantity = 5 };

            buyView
                .Setup(x => x.RequestProduct())
                .Returns(3);

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns(product);

            buyUseCase.Execute();

            Assert.Equal(4, product.Quantity);
        }

        [Fact]
        public void HavingABuyViewInstance_WhenExecuted_DispenseTheProduct()
        {
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(3);

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {
                    Quantity = 1,
                    Name = "Cola"
                });

            buyUseCase.Execute();

            buyView.Verify(x => x.DispenseProduct("Cola"), Times.Once);
        }
    }
}
