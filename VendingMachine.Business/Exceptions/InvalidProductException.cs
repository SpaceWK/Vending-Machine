using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InvalidProductException : Exception
    {
        public InvalidProductException(int columnId) : base(string.Format("The selected product {0} is invalid.", columnId)) { }
    }
}
