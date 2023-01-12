using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        public InsufficientStockException(string productName) : base(string.Format("The product {0} doesn`t exist in stock anymore.", productName)) { }
    }
}
