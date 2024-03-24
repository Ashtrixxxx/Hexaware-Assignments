using OopsTask7.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Models
{
    internal class ZeroBalance : BankAccount
    {

        public double InterestRate { get; set; } = 4.5;

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

        public override void deposit(int id, double amount)
        {
            Accounts savingsObject = bankAccounts.Find(x => x.AccountId == id);


            savingsObject.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {savingsObject.Balance}");
        }

        public override void calculateInterest(int id)
        {
            Accounts savingsObject = bankAccounts.Find(x => x.AccountId == id);

            double interest = savingsObject.Balance * (InterestRate / 100);
            Console.WriteLine($"Interest calculated: {interest}. New balance: {savingsObject.Balance}");
        }

        public override void withdraw(int id, double amount)
        {
            Accounts savingsObject = bankAccounts.Find(x => x.AccountId == id);


            if (amount <= savingsObject.Balance)
            {
                savingsObject.Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}. New balance: {savingsObject.Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        public override void TransferAmount(int sender, int receiver, double amount)
        {
            try
            {


                Accounts senderAccount = bankAccounts.Find(x => x.AccountId == sender);
                Accounts recieverAccount = bankAccounts.Find(x => x.AccountId == receiver);

                if (senderAccount == null)
                {
                    throw new Exception("The sender Id does not exist");
                }

                else if (recieverAccount == null)
                {
                    throw new Exception("The Account you are trying to send doesnot exist");
                }
                else
                {
                    senderAccount.Balance -= amount;
                    recieverAccount.Balance += amount;
                    Console.WriteLine($"The new balance of sender is {senderAccount.Balance} and reciever Account is {recieverAccount.Balance}");
                }


            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

    }
}
