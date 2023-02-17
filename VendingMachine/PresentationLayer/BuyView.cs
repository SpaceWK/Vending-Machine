using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Models;
using System;
using System.Collections.Generic;

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
            Display("You can take your product: ", ConsoleColor.Cyan);
            DisplayLine(productName, ConsoleColor.Green);
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            Console.WriteLine();
            Display("Select a payment method or X (for cancel): ", ConsoleColor.Cyan);
            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                Console.WriteLine();
                Console.WriteLine(paymentMethod.Name);
            }
            string requestedPaymentMethod = Console.ReadLine();

            if (requestedPaymentMethod == "X")
            {
                throw new CancelException();
            }

            foreach (PaymentMethod paymentMethod in paymentMethods) {
                if (requestedPaymentMethod == paymentMethod.Name)
                {
                    return paymentMethod.Id;
                }
            }

            throw new CancelException();
        }
    }
}
