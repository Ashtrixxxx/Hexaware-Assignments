using BankAssignment.Repository;
using OopsTask7.Exceptions;
using OopsTask7.Models;
using OopsTask7.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment.Services
{
    internal class BankServiceProvider
    {

        public void BankService()
        {
            int randomNumber = 1001;
            SavingsAccount savings = new SavingsAccount();
            ZeroBalance zero = new ZeroBalance();
            CurrentAccount current = new CurrentAccount();

            IBankProviderImp bankProvider = new IBankProviderImp();

        Mainmenu: while (true)
            {
                Console.WriteLine("Welcome to the Banking App");
                Console.WriteLine("1. Create A account");
                Console.WriteLine("2. List Accounts");
                Console.WriteLine("3. Calcuate Interest");
                Console.WriteLine("4. Goto Main Menu");


                Console.WriteLine("Enter Your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Select the type of Account ");
                        Console.WriteLine("1. Savings Account");
                        Console.WriteLine("2. Current Account");
                        Console.WriteLine("3. Zero Balance Account");
                        int ch = Convert.ToInt32(Console.ReadLine());
                        switch (ch)
                        {
                            case 1:

                                try
                                {
                                    Accounts accounts = new Accounts();
                                    Console.WriteLine("Enter you customer Id:");
                                    string stringId = Console.ReadLine();
                                    int accName = 0;
                                    InvalidInputException.CheckIfInteger(stringId, ref accName);

                                    Console.WriteLine("Create a account with a balance");
                                    double bal = Convert.ToDouble(Console.ReadLine());
                                    string type = "Savings";
                                    accounts = new Accounts() { CustomerId = accName, Balance = bal, AccountType = type };
                                    bankProvider.CreateAccount(accounts);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    //Console.WriteLine(savings.CustomerName);
                                }
                                break;
                            case 2:
                                try
                                {
                                    Accounts accounts = new Accounts();
                                    Console.WriteLine("Enter you customer Id:");
                                    string currentStringId = Console.ReadLine();
                                    int curraccName = 0;
                                    InvalidInputException.CheckIfInteger(currentStringId, ref curraccName);
                                    Console.WriteLine("Create a account with a balance");
                                    double currbal = Convert.ToDouble(Console.ReadLine());
                                    string currtype = "Current";
                                    accounts = new Accounts() { CustomerId = curraccName, Balance = currbal, AccountType = currtype };
                                    bankProvider.CreateAccount(accounts);
                                }catch(Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case 3:
                                try
                                {
                                    Accounts accounts = new Accounts();


                                    Console.WriteLine("Enter you customer Id:");
                                    string currentStringId = Console.ReadLine();
                                    int zeroName = 0;

                                    InvalidInputException.CheckIfInteger(currentStringId, ref zeroName);
                                    Console.WriteLine("Create a account with a balance");
                                    double zerobal = Convert.ToDouble(Console.ReadLine());
                                    string zerotype = "Zero Balance";
                                    accounts = new Accounts() { CustomerId = zeroName, Balance = zerobal, AccountType = zerotype };
                                    bankProvider.CreateAccount(accounts);
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 4:
                                goto Mainmenu;
                                break;
                            default:
                                Console.WriteLine("Invalid option");
                                goto Mainmenu;
                                break;
                        }
                        break;


                    case 2:
                        Console.WriteLine("Displaying all the Accounts in the Bank");
                        Console.WriteLine("------------------------------");

                        List<Accounts> list = new List<Accounts>();
                        list = bankProvider.listAll();
                        foreach (Accounts listall in list)
                            Console.WriteLine(listall);
                        break;
                    case 3:
                        Console.WriteLine("Calculating the interest ");


                        Console.WriteLine("Enter the Account Id you want to Calculate");
                        
                        //int interestId = Convert.ToInt32(Console.ReadLine());
                        string interestId = Console.ReadLine();

                        

                        bankProvider.CalculateInterest(interestId);


                        break;

                    default:
                        return;
                }
            }
        }
    }
}
