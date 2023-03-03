using VendingMachine.Business.Exceptions;
using VendingMachine.Business.PresentationLayer;
using System;
using System.Collections.Generic;
using VendingMachine.Business;

namespace RemoteLearning.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly IMainView mainView;

        public VendingMachineApplication(List<IUseCase> useCases, IMainView mainView)
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

                try
                {
                    IUseCase useCase = mainView.ChooseCommand(availableUseCases);
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
                catch (CancelException ex)
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