using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Repository
{
   public abstract class BankAccount
    {

        public List<BankAccount> bankAccounts;
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }

        public  double Balance { get; set; }

        public string AccountType { get; set; }

        public BankAccount()
        {
            bankAccounts = new List<BankAccount>();

        }

        public abstract void CreateAccount(BankAccount bankAccount);


        public abstract void deposit(int id,double amount);

        // Abstract method to withdraw money
        public abstract void withdraw(int id ,double amount);

        // Abstract method to calculate interest
        public abstract void calculateInterest(int id);

        // Method to display account information
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Balance: {Balance}");
        }



    }
}
