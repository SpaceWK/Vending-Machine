using RemoteLearning.VendingMachine.Exceptions;
using System;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int RequestProduct()
        {
            Console.WriteLine();
            Display("Insert a product id or X (for cancel): ", ConsoleColor.Cyan);
            string requestedId = Console.ReadLine();

            if (requestedId == "X")
            {
                throw new CancelException();
            }
            return int.Parse(requestedId);
        }

        public void DispenseProduct(string productName)
        {
            Console.WriteLine();
            DisplayLine(productName, ConsoleColor.Green);
        }
    }
}
