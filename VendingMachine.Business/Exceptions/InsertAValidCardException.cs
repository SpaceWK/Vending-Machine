namespace VendingMachine.Business.Exceptions
{
    internal class InsertAValidCardException : Exception
    {
        private const string DefaultMessage = "The card inserted is not valid";
        public InsertAValidCardException() : base(DefaultMessage) { }
    }
}
