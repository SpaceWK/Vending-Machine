using VendingMachine.Business.Exceptions;
using VendingMachine.Business.PresentationLayer;

namespace VendingMachine.Business.Payment
{
    internal class CardPayment : IPaymentAlgorithm
    {
        private readonly ICardPaymentTerminal cardTerminal;

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
