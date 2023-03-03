using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Models;
using VendingMachine.Business.PresentationLayer;

namespace VendingMachine.Business.Payment
{
    internal class PaymentService : IPaymentService
    {
        private readonly IBuyView buyView;
        private readonly List<IPaymentAlgorithm> paymentAlgorithms;
        private static ICollection<PaymentMethod> paymentMethods;

        public PaymentService(IBuyView buyView, List<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
            paymentMethods = InitializePaymentList(paymentAlgorithms);
        }

        public void Execute(float price)
        {
            IPaymentAlgorithm paymentAlgorithm = ChoosePaymentAlgorithm();
            paymentAlgorithm.Run(price);
        }

        private IPaymentAlgorithm ChoosePaymentAlgorithm()
        {
            int paymentMethodId = buyView.AskForPaymentMethod(paymentMethods);

            if (paymentMethods.FirstOrDefault(x => x.Id == paymentMethodId) == null)
            {
                throw new CancelException();
            }

            PaymentMethod selectedMethod = paymentMethods.FirstOrDefault(x => x.Id == paymentMethodId);

            if (paymentAlgorithms.Count() == 0)
            {
                throw new CancelException();
            }

            var paymentAlgorithm = paymentAlgorithms.FirstOrDefault(x => x.Name == selectedMethod.Name);

            return paymentAlgorithm;
        }

        private List<PaymentMethod> InitializePaymentList(List<IPaymentAlgorithm> paymentAlgorithms)
        {
            if(paymentAlgorithms.Count == 0)
            {
                throw new CancelException("Payment Algorithm list is empty.");
            }

            var paymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < paymentAlgorithms.Count; i++)
            {
                paymentMethods.Add(new PaymentMethod() { Id = i + 0 , Name = paymentAlgorithms[i].Name }); 
            }

            return paymentMethods;
        }
    }
}
