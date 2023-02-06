using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CardPayment : IPaymentAlgorithm
    {
        CardPaymentTerminal cardTerminal = new CardPaymentTerminal();

        public string Name => "card";

        public CardPayment(CardPaymentTerminal cardTerminal)
        {
            this.cardTerminal = cardTerminal ?? throw new ArgumentNullException(nameof(cardTerminal));
        }

        public void Run(float price)
        {
            while (true)
            {
                string insertedCard = cardTerminal.AskForCardNumber();
                if (insertedCard.Length == 16)
                {
                    double result;
                    if (double.TryParse(insertedCard, out result))
                    {
                        break;
                    }
                }
                else
                {
                    throw new InsertAValidCardException();
                }
            }
        }
    }
}
