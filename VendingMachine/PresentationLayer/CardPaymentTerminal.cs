using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            Console.WriteLine();
            Display("Insert card number: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}
