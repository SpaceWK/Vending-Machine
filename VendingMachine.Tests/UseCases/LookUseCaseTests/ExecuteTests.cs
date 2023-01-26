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
        public void HavingALookUseCaseInstance_WhenExecuted_TheProductWithNonZeroQuantityAreTakenAndDisplayed()
        {
            ICollection<Product> productsList = productRepository.Object.GetAllProducts();

            productRepository
                .Setup(x => x.GetByColumnId(It.IsAny<int>()))
                .Returns(productsList);

            lookUseCase.Execute();

            foreach (Product product in productsList)
            {
                if (product.Quantity == 0)
                {
                    productsList = productsList.Where(product => product.Quantity != 0).ToList();
                }
            }
            lookView.Object.DisplayProducts(productsList);
        }

        [Fact]
        public void HavingALookUseCaseInstance_WhenExecuted_()
        {
            lookUseCase.Execute();
            productRepository.Verify(x => x.GetAllProducts(), Times.Once());
        }
    }
}
