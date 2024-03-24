using System;
using System.ComponentModel.Design;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM!");

            // Ask user to enter current balance
            Console.Write("Enter your current balance: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

        // Display options
        Menu: while (true) {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.Write("\nEnter your choice (1/2/3): "); 
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"\nYour current balance is: {balance}");
                        break;
                    case 2:
                        Console.Write("\nEnter amount to withdraw: ");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        if (withdrawAmount > balance)
                        {
                            Console.WriteLine("Insufficient balance.");
                        }

                        else
                        {
                            balance -= withdrawAmount;
                            Console.WriteLine($"Successfully withdrawn {withdrawAmount}. Remaining balance: {balance}");
                        }
                        break;
                    case 3:
                        Console.Write("\nEnter amount to deposit: ");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        if (depositAmount <= 0)
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                        
                        else
                        {
                            balance += depositAmount;
                            Console.WriteLine($"Successfully deposited {depositAmount}. New balance: {balance}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        goto Menu;
                        break;
                }
            }
        }
    }
}
