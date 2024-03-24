using OopsTask7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment.Repository
{
    internal class ICustomerProviderImp : ICustomerProvider
    {


        public override void getAccountDetails(int id)
        {
            Accounts account = bankAccounts.Find(x => x.AccountId == id);
            Console.WriteLine(account);

        }

        public override void deposit(int id, double amount)
        {
            Accounts savingsObject = bankAccounts.Find(x => x.AccountId == id);


            savingsObject.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {savingsObject.Balance}");
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

        public override void GetAccountBalance(int id)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
            Console.WriteLine($"The bank balance for the account {currentAccount.AccountId} is {currentAccount.Balance}");
        }

    }
}
