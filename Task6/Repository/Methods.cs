using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Models;
namespace Task6.Repository
{
    internal class Methods
    {

        List<Transaction> transactions = new List<Transaction>();
        public void Deposit(double depositamount) {
            transactions.Add(new Transaction("Deposit", depositamount));

        }

        public void Withdraw(double withdrawamount) { 
        transactions.Add(new Transaction("Withdraw",withdrawamount));   
        }

        public void displayAllTransactions()
        {
            foreach(Transaction transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

    }
}

