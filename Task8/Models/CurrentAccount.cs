using OopsTask7.Repository;
using System;
using System.Collections.Generic;

namespace OopsTask7.Models
{
    internal class CurrentAccount : BankAccount
    {
        public double OverDraftLimit { get; set; } = 10000;

        public override void CreateAccount(Accounts bankAccount)
        {
            bankAccounts.Add(bankAccount);
            Console.WriteLine($"Your Account has been created naming {bankAccount.CustomerName} and the AccountId is  {bankAccount.AccountId}");
        }
        public override void listAll()
        {
            foreach (Accounts acc in bankAccounts)
            {
                Console.WriteLine(acc);
            }
        }
        public override void deposit(int id, double amount)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
            currentAccount.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {currentAccount.Balance}");
        }

        public override void calculateInterest(int id)
        {
            Console.WriteLine("Current account has no interest");
        }

        public override void withdraw(int id, double amount)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
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

        public override void getAccountDetails(int id)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
            Console.WriteLine(currentAccount);
        }

        public override void GetAccountBalance(int id)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
            Console.WriteLine($"The bank balance for the account {currentAccount.AccountId} is {currentAccount.Balance}");
        }

        public override void TransferAmount(int sender, int receiver, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
