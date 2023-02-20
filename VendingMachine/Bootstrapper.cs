using System.Collections.Generic;
using System.Net.Http.Headers;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.Payment;
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
            ICardPaymentTerminal cardPaymentTerminal = new CardPaymentTerminal();
            ICashPaymentTerminal cashPaymentTerminal = new CashPaymentTerminal();

            IAuthenticationService authenticationService = new AuthenticationService();
            List<IPaymentAlgorithm> paymentAlgorithms = new() { new CashPayment(cashPaymentTerminal), new CardPayment(cardPaymentTerminal) };
            IPaymentService paymentService = new PaymentService(buyView, paymentAlgorithms);
            IProductRepository memoryProducts = new ProductRepository();
            IProductRepository liteDbProducts = new LiteDBPRoductRepository(@"D:\Nagarro\Temp\MyData.db");

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(authenticationService, liteDbProducts, shelfView),
                new BuyUseCase(authenticationService, liteDbProducts, buyView, paymentService),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}