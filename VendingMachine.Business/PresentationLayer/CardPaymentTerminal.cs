using RemoteLearning.VendingMachine.Exceptions;
using System;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            string input = String.Empty;
            bool isConvertable = false;

            Console.WriteLine();
            while (!isConvertable)
            {
                Display("Insert card number or press X to cancel: ", ConsoleColor.Cyan);
                input = Console.ReadLine();

                isConvertable = double.TryParse(input, out _);

                if (string.IsNullOrEmpty(input))
                {
                    DisplayLine("Nothing entered: ", ConsoleColor.Red);
                }
                else if (!isConvertable && input != "X")
                {
                    DisplayLine("Invalid format: ", ConsoleColor.Red);
                }
                else if (input == "X")
                {
                    return null;
                }
            }
            return input;
        }
    }
}
