using System.Threading.Tasks;
using System;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Task 4: Looping, Array and Data Validation
            //You are tasked with creating a program that allows bank customers to check their account balances.
            //The program should handle multiple customer accounts, and the customer should be able to enter their
            //account number, balance to check the balance.
            //Tasks:
            //1.Create a Python program that simulates a bank with multiple customer accounts.
            //2.Use a loop(e.g., while loop) to repeatedly ask the user for their account number and
            //balance until they enter a valid account number.
            //3.Validate the account number entered by the user.
            //4.If the account number is valid, display the account balance.If not, ask the user to try again.

            string[] accountId = { "12345", "12534", "23456" };
            double[] balance = { 10000.00, 20000.00, 15900.00 };

            while(true)
            {
                Console.WriteLine("Enter your accout number");
                 string id= Console.ReadLine();
                int index = Avail(id,accountId);
                if (index < 0)
                {
                    Console.WriteLine("No user found");
                }
                else
                {
                    Console.WriteLine($"the balance for the account id{accountId[index]} is {balance[index]}");
                }

            }


            
        }

        public static int Avail(string id, string[] accountId)
        {
            // Check if the entered account ID exists in the array
            for (int i = 0; i < accountId.Length; i++)
            {
                if (accountId[i].Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }



    }
}
