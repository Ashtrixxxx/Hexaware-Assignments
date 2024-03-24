using System.Globalization;
using OopsTask7.Models;
namespace OopsTask7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Banking System!");

            // Choose the account type
            Console.WriteLine("Select the account type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            int accountTypeChoice = Convert.ToInt32(Console.ReadLine());

            switch (accountTypeChoice)
            {
                case 1:

                    SavingsAccount savings = new SavingsAccount();
                    Console.WriteLine("Savings Account Menu:");
                    Console.WriteLine("1. Create a bank account");
                    Console.WriteLine("2. Deposit money");
                    Console.WriteLine("3. Withdraw money");
                    Console.WriteLine("4. Calculate interest");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Creating a savings account...");
                            Console.WriteLine("Create Your Account id:");
                            int accId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Create your Account Name:");
                            string accName = Console.ReadLine();
                            double bal = 0;
                            string type = "Savings";
                            savings = new SavingsAccount() { AccountNumber = accId, CustomerName = accName, Balance = bal, AccountType = type };
                            savings.CreateAccount(savings);
                            //Console.WriteLine(savings.CustomerName);
                            break;
                        case 2:
                            Console.WriteLine("Depositing money into savings account...");
                            Console.WriteLine("Enter your account id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter your money");
                            double money = Convert.ToDouble(Console.ReadLine());

                            savings.deposit(id, money);

                            // Implement logic to deposit money into a savings account
                            break;
                        case 3:
                            Console.WriteLine("Withdrawing money from savings account...");
                            Console.WriteLine("Depositing money into savings account...");
                            Console.WriteLine("Enter your account id");
                            int withdrawid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter your money");
                            double addMoney = Convert.ToDouble(Console.ReadLine());

                            savings.withdraw(withdrawid, addMoney);

                            break;
                        case 4:
                            Console.WriteLine("Calculating interest for savings account...");
                            int calInterestId = Convert.ToInt32(Console.ReadLine());
                            savings.calculateInterest(calInterestId);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                    break;
                case 2:

                    CurrentAccount current = new CurrentAccount();
                    Console.WriteLine("Current Account Menu:");
                    Console.WriteLine("1. Create a bank account");
                    Console.WriteLine("2. Deposit money");
                    Console.WriteLine("3. Withdraw money");
                    int currentChoice = Convert.ToInt32(Console.ReadLine());

                    switch (currentChoice)
                    {
                        case 1:
                            Console.WriteLine("Creating a current account...");
                            Console.WriteLine("Create Your Account id:");
                            int accId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Create your Account Name:");
                            string accName = Console.ReadLine();
                            double bal = 0;
                            string type = "Savings";
                            current = new CurrentAccount() { AccountNumber = accId, CustomerName = accName, Balance = bal, AccountType = type };
                            current.CreateAccount(current); break;
                        case 2:
                            Console.WriteLine("Depositing money into current account...");
                            Console.WriteLine("Enter your account id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter your money");
                            double money = Convert.ToDouble(Console.ReadLine());

                            current.deposit(id, money); break;
                        case 3:
                            Console.WriteLine("Withdrawing money from current account...");
                            Console.WriteLine("Depositing money into savings account...");
                            Console.WriteLine("Enter your account id");
                            int withdrawid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter your money");
                            double addMoney = Convert.ToDouble(Console.ReadLine());

                            current.withdraw(withdrawid, addMoney); 
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
