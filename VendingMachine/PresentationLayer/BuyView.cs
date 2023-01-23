using System;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
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
