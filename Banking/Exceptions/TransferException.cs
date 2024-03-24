using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Exceptions
{
    internal class TransferException: Exception

    {

        public TransferException(string message):base(message) { }
    }
}
