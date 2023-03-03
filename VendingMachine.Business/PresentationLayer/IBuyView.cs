using VendingMachine.Business.Models;

namespace VendingMachine.Business.PresentationLayer
{
    internal interface IBuyView
    {
        int RequestProduct();
        void DispenseProduct(string productName);
        int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
