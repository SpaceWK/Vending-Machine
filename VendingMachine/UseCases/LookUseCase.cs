using System;
using System.Collections.Generic;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.PresentationLayer;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly IShelfView shelfView;
        private readonly IProductRepository products;
        private readonly IAuthenticationService authenticationService;

        public string Name => "look";

        public string Description => "Now you can see the shelf";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LookUseCase(IAuthenticationService authenticationService, IProductRepository products, IShelfView shelfView)
        {
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.products = products ?? throw new ArgumentNullException(nameof(products));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            List<Product> productsList = new List<Product>();
            foreach (Product product in products.GetAllProducts())
            {
                if (product.Quantity > 0)
                {
                    productsList.Add(product);
                }
            }
            shelfView.DisplayProducts(productsList);
        }
    }
}
