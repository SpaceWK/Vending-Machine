namespace VendingMachine.Business.PresentationLayer
{
    internal interface IMainView
    {
        void DisplayApplicationHeader();
        IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
    }
}