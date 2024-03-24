using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Task 3: Loop Structures
            //You are responsible for calculating compound interest on savings accounts for bank customers. You
            //need to calculate the future balance for each customer's savings account after a certain number of years.
            //Tasks:
            //1.Create a program that calculates the future balance of a savings account.
            //2.Use a loop structure(e.g., for loop) to calculate the balance for multiple customers.
            //3.Prompt the user to enter the initial balance, annual interest rate, and the number of years.
            //4.Calculate the future balance using the formula:
            //future_balance = initial_balance * (1 + annual_interest_rate / 100) ^ years.
            //5.Display the future balance for each customer.

            Console.WriteLine("Enter number of customers:");
            int n = Convert.ToInt32( Console.ReadLine());
            for(int i = 0;i<n ; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter your initial balance for Customer {i}");
                int initial = Convert.ToInt32( Console.ReadLine());
                Console.WriteLine("Enter your interest rate");
                double rate = Convert.ToDouble( Console.ReadLine());
                Console.WriteLine("Enter number of years");
                int years= Convert.ToInt32( Console.ReadLine());

                double future = initial * Math.Pow((double)(1 + rate), years);
                Console.WriteLine($"The future balance of customer {i} is {future}");

            }

        }
    }
}
