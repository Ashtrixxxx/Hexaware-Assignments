using BankAssignment.Repository;
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

            IBankProviderImp Ibank = new IBankProviderImp();

        Mainmenu: while (true)
            {
                Console.WriteLine("Welcome to the Banking App");
                Console.WriteLine("1. Create A account");
                Console.WriteLine("2. List Accounts");
                Console.WriteLine("3. Calcuate Interest");



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
                                Accounts accounts = new Accounts();
                                int accId = randomNumber++;
                                Console.WriteLine("Enter you customer name:");
                                int accName = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Create a account with a balance");
                                double bal = Convert.ToDouble(Console.ReadLine());
                                string type = "Savings";
                                accounts = new Accounts() { AccountId = accId, CustomerId = accName, Balance = bal, AccountType = type };
                                Ibank.CreateAccount(accounts);
                                //Console.WriteLine(savings.CustomerName);
                                break;
                            case 2:
                                int currentacc = randomNumber++;
                                Console.WriteLine("Enter you customer name:");
                                int curraccName = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Create a account with a balance");
                                double currbal = Convert.ToDouble(Console.ReadLine());
                                string currtype = "Current";
                                accounts = new Accounts() { AccountId = currentacc, CustomerId = curraccName, Balance = currbal, AccountType = currtype };
                                Ibank.CreateAccount(accounts);
                                break;
                            case 3:
                                int zeroId = randomNumber++;
                                Console.WriteLine("Enter you customer name:");
                                int zeroName = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Create a account with a balance");
                                double zerobal = Convert.ToDouble(Console.ReadLine());
                                string zerotype = "Zero Balance";
                                accounts = new Accounts() { AccountId = zeroId, CustomerId = zeroName, Balance = zerobal, AccountType = zerotype };
                                Ibank.CreateAccount(accounts);
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
                        list = Ibank.listAll();
                        foreach (Accounts listall in list)
                            Console.WriteLine(listall);
                        break;
                    case 3:
                        Console.WriteLine("Calculating the interest ");
                        Console.WriteLine("Enter the Account Id you want to Calculate");
                        int interestId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Account Type");
                        string interestType = Console.ReadLine();
                        //if(interestType == "Savings")
                        //{
                        //    savings.calculateInterest(interestId);
                        //}
                        //else if(interestType == "Current"){
                        //    current.calculateInterest(interestId);
                        //}
                        //else
                        //{
                        //    zero.calculateInterest(interestId);
                        //}

                        Ibank.CalculateInterest(interestId);


                        break;

                    default:
                        return;
                }
            }
        }
    }
}
