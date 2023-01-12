using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase
    {
        public string RequestProduct()
        {
            Console.WriteLine();
            Display("Insert a product id or X (for cancel): ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }

        public void DispenseProduct(string productName)
        {
            Console.WriteLine();
            DisplayLine(productName, ConsoleColor.Green);
        }
    }
}
