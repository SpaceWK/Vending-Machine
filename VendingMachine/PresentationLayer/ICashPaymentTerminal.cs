using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface ICashPaymentTerminal
    {
        float AskForMoney();
        void GiveBackChange(float price);
    }
}
