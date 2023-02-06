using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.Payment
{
    internal interface IPaymentAlgorithm
    {
        string Name { get; }

        void Run(float price);
    }
}
