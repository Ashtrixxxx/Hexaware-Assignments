using Task6.Models;
using Task6.Repository;
namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Methods methods = new Methods();
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a deposit");
                Console.WriteLine("2. Add a withdrawal");
                Console.WriteLine("3. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        methods.Deposit(depositAmount);                        
                        break;
                    case 2:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawalAmount= Convert.ToDouble(Console.ReadLine());
                        methods.Withdraw(withdrawalAmount);
                        break;
                    case 3:
                        Console.WriteLine("Transaction history:");
                        methods.displayAllTransactions();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }

        }
    }
}
