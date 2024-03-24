using OopsTask7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Repository
{
   public abstract class BankAccount
    {

        public List<Accounts> bankAccounts;

        public BankAccount()
        {
            bankAccounts = new List<Accounts>();

        }

        public abstract void listAll();

        public abstract void CreateAccount(Accounts bankAccount);

        public abstract void GetAccountBalance(int id);

        public abstract void TransferAmount(int sender, int receiver , double amount);

        public abstract void getAccountDetails(int id);

        public abstract void deposit(int id,double amount);

        // Abstract method to withdraw money
        public abstract void withdraw(int id ,double amount);

        // Abstract method to calculate interest
        public abstract void calculateInterest(int id);

        // Method to display account information
       
      

    }
}
