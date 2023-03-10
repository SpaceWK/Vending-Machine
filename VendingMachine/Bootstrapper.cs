using VendingMachine.Business.Authentication;
using RemoteLearning.VendingMachine.DataAccess;
using VendingMachine.Business.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using VendingMachine.Business.UseCases;
using System.Collections.Generic;
using VendingMachine.Business.PresentationLayer;
using VendingMachine.Business.DataAccess;
using VendingMachine.Business;

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
            IMainView mainView = new MainView();
            ILoginView loginView = new LoginView();
            IShelfView shelfView = new ShelfView();
            IBuyView buyView = new BuyView();
            ICardPaymentTerminal cardPaymentTerminal = new CardPaymentTerminal();
            ICashPaymentTerminal cashPaymentTerminal = new CashPaymentTerminal();

            IAuthenticationService authenticationService = new AuthenticationService();
            List<IPaymentAlgorithm> paymentAlgorithms = new() { new CashPayment(cashPaymentTerminal), new CardPayment(cardPaymentTerminal) };
            IPaymentService paymentService = new PaymentService(buyView, paymentAlgorithms);
            IProductRepository productRepository = new LiteDBProductRepository(@"D:\Nagarro\Temp\MyData.db");

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(authenticationService, productRepository, shelfView),
                new BuyUseCase(authenticationService, productRepository, buyView, paymentService),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}