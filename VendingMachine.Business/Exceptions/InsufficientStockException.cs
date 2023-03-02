using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        public InsufficientStockException(string productName) : base(string.Format("The product {0} doesn`t exist in stock anymore.", productName)) { }
    }
}
