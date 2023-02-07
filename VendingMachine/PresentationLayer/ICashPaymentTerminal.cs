using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface ICashPaymentTerminal
    {
        string AskForMoney();
        void GiveBackMoney(float price);
    }
}
