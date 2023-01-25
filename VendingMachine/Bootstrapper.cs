using System.Collections.Generic;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;

namespace RemoteLearning.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainView mainView = new MainView();
            ILoginView loginView = new LoginView();
            IShelfView shelfView = new ShelfView();
            IBuyView buyView = new BuyView();

            IAuthenticationService authenticationService = new AuthenticationService();
            IProductRepository products = new ProductRepository();

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(authenticationService, products, shelfView),
                new BuyUseCase(authenticationService, products, buyView),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}