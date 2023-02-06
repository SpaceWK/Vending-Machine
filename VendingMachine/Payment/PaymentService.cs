using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.Payment
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

            paymentMethods = new List<PaymentMethod>() {
                new PaymentMethod {
                    Id = 1,
                    Name = "cash"
                },
                new PaymentMethod {
                    Id = 2,
                    Name = "card"
                }
            };
        }

        public void Execute(float price)
        {
            IPaymentAlgorithm paymentAlgorithm = ChoosePaymentAlgorithm();
            paymentAlgorithm.Run(price);
        }

        private IPaymentAlgorithm ChoosePaymentAlgorithm()
        {
            int paymentMethodId = buyView.AskForPaymentMethod(paymentMethods);

            if(paymentMethods.FirstOrDefault(x => x.Id == paymentMethodId) == null) {
                throw new CancelException();
            }

            PaymentMethod selectedMethod = paymentMethods.FirstOrDefault(x => x.Id == paymentMethodId);

            if (paymentAlgorithms.FirstOrDefault(x => x.Name == selectedMethod.Name) == null)
            {
                throw new CancelException();
            }

            var paymentAlgorithm = paymentAlgorithms.FirstOrDefault(x => x.Name == selectedMethod.Name);

            return paymentAlgorithm;
        }
    }
}
