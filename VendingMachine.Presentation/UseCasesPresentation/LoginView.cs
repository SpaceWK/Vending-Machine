using VendingMachine.Business.PresentationLayer;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class LoginView : DisplayBase, ILoginView
    {
        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}