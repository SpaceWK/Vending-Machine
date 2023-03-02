using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CardPayment : IPaymentAlgorithm
    {
        ICardPaymentTerminal cardTerminal = new CardPaymentTerminal();

        public string Name => "card";

        public CardPayment(ICardPaymentTerminal cardTerminal)
        {
            this.cardTerminal = cardTerminal ?? throw new ArgumentNullException(nameof(cardTerminal));
        }

        public void Run(float price)
        {
            bool isValidCard = false;
            while (!isValidCard)
            {
                string insertedCard = cardTerminal.AskForCardNumber();

                if (insertedCard == null)
                {
                    throw new CancelException();
                }

                isValidCard = IsValidCardNumber(insertedCard);
                if (!isValidCard)
                    continue;

                break;
            }
        }

        private bool IsValidCardNumber(string cardNumber)
        {
            int numberOfDigits = cardNumber.Length;
            int sum = 0;
            bool isSecondDigit = false;
            for (int i = numberOfDigits - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0';
                if (isSecondDigit)
                {
                    digit *= 2;
                }
                sum += digit / 10 + digit % 10;
                isSecondDigit = !isSecondDigit;
            }
            return sum % 10 == 0;
        }
    }
}
