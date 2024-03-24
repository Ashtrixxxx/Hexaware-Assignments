using OopsTask7.Repository;
using System;
using System.Collections.Generic;

namespace OopsTask7.Models
{
    internal class CurrentAccount : BankAccount
    {
        public double OverDraftLimit { get; set; } = 10000;

        public override void CreateAccount(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount);
            Console.WriteLine($"{bankAccount.CustomerName}  {bankAccount.AccountNumber}");
        }

        public override void deposit(int id, double amount)
        {
            BankAccount currentAccount = bankAccounts.Find(x => x.AccountNumber == id);
            currentAccount.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {currentAccount.Balance}");
        }

        public override void calculateInterest(int id)
        {
            Console.WriteLine("Current account has no interest");
        }

        public override void withdraw(int id, double amount)
        {
            BankAccount currentAccount = bankAccounts.Find(x => x.AccountNumber == id);
            if (amount <= currentAccount.Balance + OverDraftLimit)
            {
                currentAccount.Balance -= amount;
                Console.WriteLine("Amount debited successfully");
            }
            else
            {
                Console.WriteLine("Withdrawal amount exceeds overdraft limit");
            }
        }
    }
}
