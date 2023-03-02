using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CashPayment : IPaymentAlgorithm
    {
        ICashPaymentTerminal cashTerminal = new CashPaymentTerminal();

        public string Name => "cash";

        public CashPayment(ICashPaymentTerminal cashTerminal)
        {
            this.cashTerminal = cashTerminal ?? throw new ArgumentNullException(nameof(cashTerminal));
        }

        public void Run(float productPrice)
        {
            float totalMoneyInserted = 0.0f;

            while (totalMoneyInserted < productPrice)
            {
                string input = cashTerminal.AskForMoney();

                if (input == null)
                {
                    cashTerminal.GiveBackMoney(totalMoneyInserted);
                    throw new CancelException();
                }
                
                float insertedMoney = float.Parse(input);
                totalMoneyInserted += insertedMoney;
            }

            float change = totalMoneyInserted - productPrice;
            cashTerminal.GiveBackMoney(change);
        }
    }
}
