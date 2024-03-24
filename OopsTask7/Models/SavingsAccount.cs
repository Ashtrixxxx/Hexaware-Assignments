using OopsTask7.Repository;
using System;

namespace OopsTask7.Models
{
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; } = 4.5;

        public override void CreateAccount(BankAccount bankAccount)
        {
                bankAccounts.Add(bankAccount);
            Console.WriteLine($"{bankAccount.CustomerName}  {bankAccount.AccountNumber}");

        }



        public override void deposit(int id , double amount)
        {
            BankAccount savingsObject = bankAccounts.Find(x=> x.AccountNumber == id);


            savingsObject.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {savingsObject.Balance}");
        }

        public override void calculateInterest(int id)
        {
            BankAccount savingsObject = bankAccounts.Find(x => x.AccountNumber == id);

            double interest = savingsObject.Balance * (InterestRate / 100);
            Console.WriteLine($"Interest calculated: {interest}. New balance: {savingsObject.Balance}");
        }
                                                            
        public override void withdraw(int id,double amount)
        {
            BankAccount savingsObject = bankAccounts.Find(x => x.AccountNumber == id);


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


    }
}
