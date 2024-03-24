using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Exceptions
{
    internal class InvalidInputException: Exception
    {

        public InvalidInputException(string message):base(message) { }



        public static void CheckIfInteger(string message,ref int dId)
        {
            if(!int.TryParse(message,out int value1))
            {
                throw new InvalidInputException("Please Provide input in Number Format..");
            }
            dId = value1;
        }
    }
}
