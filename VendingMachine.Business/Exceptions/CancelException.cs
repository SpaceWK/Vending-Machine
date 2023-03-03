namespace VendingMachine.Business.Exceptions
{
    internal class CancelException : Exception
    {
        private const string DefaultMessage = "You have canceled the operation";
        public CancelException() : base(DefaultMessage) { }

        public CancelException(string message) : base(DefaultMessage) { }
    }
}
