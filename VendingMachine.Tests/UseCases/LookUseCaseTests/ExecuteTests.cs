using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
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
                .Setup(x => x.GetAllProducts())
                .Returns(new List<Product>() {
                    new Product {
                        ColumnId = 1,
                        Name = "Chocolate",
                        Price = 5,
                        Quantity = 15
                    }
                });

            lookUseCase.Execute();

            productRepository.Verify(x => x.GetAllProducts(), Times.Once);
        }

        [Fact]
        public void HavingAProductWithZeroStock_WhenExecuted_ThenNoProductIsRetrievedFromTheProductRepository()
        {
            Product product = new Product() { Quantity = 0 };
            List<Product> productsList = new List<Product>() { product };
            List<Product> expectedProductsList = new List<Product>();

            productRepository
                .Setup(x => x.GetAllProducts())
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
                .Setup(x => x.GetAllProducts())
                .Returns(productsList);

            lookUseCase.Execute();

            lookView.Verify(x => x.DisplayProducts(expectedProductsList), Times.Once);
        }
    }
}
