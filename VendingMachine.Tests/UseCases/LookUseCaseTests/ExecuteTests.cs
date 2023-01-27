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

            var product1 = new Product { Quantity = 5 };
            var product2 = new Product { Quantity = 0 };
            var product3 = new Product { Quantity = 2 };
            productsList.Add(product1);
            productsList.Add(product2);
            productsList.Add(product3);
             
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
    }
}
