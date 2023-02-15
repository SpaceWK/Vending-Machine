using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IAuthenticationService authenticationService;

        public string Name => "buy";

        public string Description => "Now you can buy a product.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IAuthenticationService authenticationService, IProductRepository productRepository, IBuyView buyView)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            int requestedId = buyView.RequestProduct();

            Product boughtProduct = productRepository.GetByColumnId(requestedId);

            if (boughtProduct == null)
            {
                throw new InvalidProductException(requestedId);
            }
            if (boughtProduct.Quantity <= 0)
            {
                throw new InsufficientStockException(boughtProduct.Name);
            }
            
            DecrementStock(boughtProduct);
            buyView.DispenseProduct(boughtProduct.Name);
        }

        private void DecrementStock(Product boughtProduct)
        {
            boughtProduct.Quantity--;
        }
    }
}
