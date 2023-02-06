using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        public float AskForMoney()
        {
            Console.WriteLine();
            Display("Insert money: ", ConsoleColor.Cyan);
            return float.Parse(Console.ReadLine());
        }

        public void GiveBackChange(float money)
        {
            Console.WriteLine();
            Display("Your change is: ", ConsoleColor.Cyan);
            DisplayLine("" + money, ConsoleColor.Gray);
        }
    }
}
