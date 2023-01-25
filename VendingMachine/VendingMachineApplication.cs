using System;
using System.Collections.Generic;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;

namespace RemoteLearning.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainView mainView;

        public VendingMachineApplication(List<IUseCase> useCases, MainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<IUseCase> availableUseCases = GetExecutableUseCases();

                IUseCase useCase = mainView.ChooseCommand(availableUseCases);

                try
                {
                    useCase.Execute();
                }
                catch (InvalidProductException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (InsufficientStockException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}