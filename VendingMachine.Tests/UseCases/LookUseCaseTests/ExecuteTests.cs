using Moq;
using VendingMachine.Business.Authentication;
using VendingMachine.Business.DataAccess;
using VendingMachine.Business.Models;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LookUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IShelfView> lookView;

        private readonly LookUseCase lookUseCase;

        public ExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            lookView = new Mock<IShelfView>();

            lookUseCase = new LookUseCase(authenticationService.Object, productRepository.Object, lookView.Object);
        }

        [Fact]
        public void HavingALookUseCase_WhenExecuted_ThenAllProductsAreRetrievedFromRepository()
        {
            productRepository
                .Setup(x => x.GetAll())
                .Returns(new List<Product>() {
                    new Product {
                        ColumnId = 1,
                        Name = "Chocolate",
                        Price = 5,
                        Quantity = 15
                    }
                });

            lookUseCase.Execute();

            productRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void HavingAProductWithZeroStock_WhenExecuted_ThenNoProductIsRetrievedFromTheProductRepository()
        {
            Product product = new Product() { Quantity = 0 };
            List<Product> productsList = new List<Product>() { product };
            List<Product> expectedProductsList = new List<Product>();

            productRepository
                .Setup(x => x.GetAll())
                .Returns(productsList);

            lookUseCase.Execute();

            lookView.Verify(x => x.DisplayProducts(expectedProductsList), Times.Once);
        }

        [Fact]
        public void HavingALookUseCase_WhenExecuted_ThenAllEligibleProductsAreDisplayed()
        {
            Product product = new Product() { Quantity = 19 };
            List<Product> productsList = new List<Product>() { product };
            List<Product> expectedProductsList = new List<Product>() { product };

            productRepository
                .Setup(x => x.GetAll())
                .Returns(productsList);

            lookUseCase.Execute();

            lookView.Verify(x => x.DisplayProducts(expectedProductsList), Times.Once);
        }
    }
}
