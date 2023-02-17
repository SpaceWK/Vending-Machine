using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        int RequestProduct();
        void DispenseProduct(string productName);
        int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
