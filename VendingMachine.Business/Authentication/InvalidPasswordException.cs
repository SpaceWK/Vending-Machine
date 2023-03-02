using System;

namespace RemoteLearning.VendingMachine.Authentication
{
    internal class InvalidPasswordException : Exception
    {
        private const string DefaultMessage = "Invalid password";

        public InvalidPasswordException()
            : base(DefaultMessage)
        {
        }
    }
}