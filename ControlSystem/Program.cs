
using System;
using System.Security.Cryptography.X509Certificates;

namespace ControlSystem
{
    internal class ControlSystem
    {
        static void Main(String[] args)
        {

            //Console.WriteLine(hello.key);

            /* class work
            Console.WriteLine("Enter your Mark");
            int marks = Convert.ToInt32(Console.ReadLine());

            if(marks>=90)
            {
                Console.WriteLine("A");
            }
            else if (marks >= 80)
            {
                Console.WriteLine("B");
            }
            else if(marks >= 70)
            {
                Console.WriteLine("C");
            }
            else if(marks >= 60)
            {
                Console.WriteLine("D");
            }
            else
            {
                Console.WriteLine("E");
            }
            */

            /*Task 1: Conditional Statements
            In a bank, you have been given the task is to create a program that checks if a customer is eligible for
            a loan based on their credit score and income. The eligibility criteria are as follows:
            • Credit Score must be above 700.
            • Annual Income must be at least $50,000.
            Tasks:
            1. Write a program that takes the customer's credit score and annual income as input.
            2. Use conditional statements (if-else) to determine if the customer is eligible for a loan.
            3. Display an appropriate message based on eligibility.*/

            Console.WriteLine("Enter your credit score:");
            int credits = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter yout Annual income:");
            int income = Convert.ToInt32(Console.ReadLine());

            

            if (credits > 700 && income >= 50000)
            {
                Console.WriteLine("You are eligible");
            }
            else
            {
                Console.WriteLine("You are not eligible");
            }




                        /*Task 2: Nested Conditional Statements
            Create a program that simulates an ATM transaction. Display options such as "Check Balance,"
            "Withdraw," "Deposit,". Ask the user to enter their current balance and the amount they want to
            withdraw or deposit. Implement checks to ensure that the withdrawal amount is not greater than the
            available balance and that the withdrawal amount is in multiples of 100 or 500. Display appropriate
            messages for success or failure.
                        */



        }
        //task 2



        public class hello
        {
             int key = 10;
        }
    }
}