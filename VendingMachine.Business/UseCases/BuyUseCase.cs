using VendingMachine.Business.Authentication;
using VendingMachine.Business.DataAccess;
using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Models;
using VendingMachine.Business.Payment;
using VendingMachine.Business.PresentationLayer;

namespace VendingMachine.Business.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IAuthenticationService authenticationService;
        private readonly IPaymentService paymentService;

        public string Name => "buy";

        public string Description => "Now you can buy a product.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IAuthenticationService authenticationService, IProductRepository productRepository, IBuyView buyView, IPaymentService paymentService)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
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

            paymentService.Execute(boughtProduct.Price);

            DecrementStock(boughtProduct);
            productRepository.Update(boughtProduct);
            buyView.DispenseProduct(boughtProduct.Name);
        }

        private void DecrementStock(Product boughtProduct)
        {
            boughtProduct.Quantity--;
        }
    }
}
