using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Models
{
    public class Accounts
    {
        

        public Accounts()
        {
            
        }

        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public string CustomerName { get; set; }

        public int CustomerId { get; set; }

        //Methods 

        public override string ToString()
        {
            return $"{AccountId} \t {AccountType} {CustomerName} \t {Balance}";
        }
        public void deposit(double  amount)
        {
            if (amount > 0)
            {
                Balance = Balance + amount;
                Console.WriteLine("Amount Credited successfully");
            }
            else
            {
                Console.WriteLine("Enter valid amount");
            }
        }

        public void deposit(int amount)
        {
            if (amount > 0)
            {
                Balance = Balance + amount;
                Console.WriteLine("Amount Credited successfully");
            }
            else
            {
                Console.WriteLine("Enter valid amount");
            }

        }


        public virtual void withdraw(int amount)
        {
            if (amount < Balance)
            {
                Balance -= amount;
                Console.WriteLine("Amount debited successfully");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }

        public virtual void withdraw(double amount)
        {

            if (amount < Balance)
            {
                Balance -= amount;
                Console.WriteLine("Amount debited successfully");
            } else
            {
                Console.WriteLine("Insufficient balance");
            }
        }

        public virtual double calculateInterest()
        {
            double rate = 4.5 / 100;
            double interest = rate * Balance;
            return interest;  
        }


    }
}
