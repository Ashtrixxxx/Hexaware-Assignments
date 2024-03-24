using System;

namespace OopsTask7.Models
{
    internal class Banking
    {
       Accounts a = new Accounts();

        public void deposit(int amount)
        {
            a.deposit(amount);
        }

        public void withdraw(int amount)
        {
            a.withdraw(amount);
        }

        public double calInterest()
        {

            return a.calculateInterest();
        }
    }
}
