using RemoteLearning.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CashPayment : IPaymentAlgorithm
    {
        CashPaymentTerminal cashTerminal = new CashPaymentTerminal();

        public string Name => "cash";

        public CashPayment(CashPaymentTerminal cashTerminal)
        {
            this.cashTerminal = cashTerminal ?? throw new ArgumentNullException(nameof(cashTerminal));
        }

        public void Run(float productPrice)
        {
            float insertedMoney = cashTerminal.AskForMoney();
            float change = insertedMoney - productPrice;
            cashTerminal.GiveBackChange(change);
        }
    }
}
