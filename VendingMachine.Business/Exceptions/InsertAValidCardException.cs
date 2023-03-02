using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InsertAValidCardException : Exception
    {
        private const string DefaultMessage = "The card inserted is not valid";
        public InsertAValidCardException() : base(DefaultMessage) { }
    }
}
