using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment.Exceptions
{
    internal class NoSufficientFundsAvailable:Exception
    {
        public NoSufficientFundsAvailable(string message):base(message) { }
    }
}
