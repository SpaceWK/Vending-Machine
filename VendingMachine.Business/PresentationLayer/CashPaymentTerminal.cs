using RemoteLearning.VendingMachine.Exceptions;
using System;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        public string AskForMoney()
        {
            Console.WriteLine();
            Display("Insert money or X (for cancel): ", ConsoleColor.Cyan);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                DisplayLine("Nothing entered: ", ConsoleColor.Red);
                Display("Insert money or X (for cancel): ", ConsoleColor.Cyan);
                input = Console.ReadLine();
            }
            if (input == "X")
            {
                return null;
            }
            
            return input;
        }

        public void GiveBackMoney(float money)
        {
            Console.WriteLine();
            Display("Your change is: ", ConsoleColor.Cyan);
            DisplayLine("" + money, ConsoleColor.Gray);
        }
    }
}
