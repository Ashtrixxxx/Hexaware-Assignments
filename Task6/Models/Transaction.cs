using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Models
{
    internal class Transaction
    {
        double amount;
        string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Transaction(string transactionType, double ipAmount)
        {
            Amount = ipAmount;
            Type = transactionType;

        }

        public override string ToString()
        {
            string myString = Type == "Deposit" ? "Deposit" : "Withdraw";
            return $"{myString} : {Amount}";
        }


    }
}
