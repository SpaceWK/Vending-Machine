using VendingMachine.Business;
using VendingMachine.Business.PresentationLayer;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class MainView : DisplayBase, IMainView
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }
    }
}