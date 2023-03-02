using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class CancelException : Exception
    {
        private const string DefaultMessage = "You have canceled the operation";
        public CancelException() : base(DefaultMessage) { }
    }
}
