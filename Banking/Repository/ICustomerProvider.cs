using OopsTask7.Models;
using OopsTask7.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment.Repository
{
    internal abstract class ICustomerProvider : Accounts
    {

        public abstract void GetAccountBalance(int id);

        public abstract void TransferAmount(int sender, int receiver, double amount);

        public abstract void getAccountDetails(int id);

        public abstract void deposit(int id, double amount);

        // Abstract method to withdraw money
        public abstract void withdraw(int id, double amount);
    }
}
