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
            LoginView loginView = new LoginView();
            ShelfView shelfView = new ShelfView();

            AuthenticationService authenticationService = new AuthenticationService();
            ProductRepository products = new ProductRepository();

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(products, shelfView),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}