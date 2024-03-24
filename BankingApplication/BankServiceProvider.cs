using OopsTask7.Models;
using OopsTask7.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7
{
    internal class BankServiceProvider
    {

        public void BankService()
        {
            int randomNumber = 1000;
            SavingsAccount savings = new SavingsAccount();
            ZeroBalance zero = new ZeroBalance();
            CurrentAccount current = new CurrentAccount();
        Mainmenu: while (true)
            {
                Console.WriteLine("Welcome to the Banking App");
                Console.WriteLine("1. Get Account Balance");
                Console.WriteLine("2. List Accounts");
                Console.WriteLine("3. Withdraw Money");
                

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
                                Console.WriteLine("Create your Account Name:");
                                string accName = Console.ReadLine();
                                Console.WriteLine("Create a account with a balance");
                                double bal = Convert.ToDouble(Console.ReadLine());
                                string type = "Savings";
                                accounts = new Accounts() { AccountId = accId, CustomerName = accName, Balance = bal, AccountType = type };
                                savings.CreateAccount(accounts);
                                //Console.WriteLine(savings.CustomerName);
                                break;
                            case 2:
                                int currentacc = randomNumber++;
                                Console.WriteLine("Create your Account Name:");
                                string curraccName = Console.ReadLine();
                                Console.WriteLine("Create a account with a balance");
                                double currbal = Convert.ToDouble(Console.ReadLine());
                                string currtype = "Current";
                                accounts = new Accounts() { AccountId = currentacc, CustomerName = curraccName, Balance = currbal, AccountType = currtype };
                                current.CreateAccount(accounts);
                                break;
                            case 3:
                                int zeroId = randomNumber++;
                                Console.WriteLine("Create your Account Name:");
                                string zeroName = Console.ReadLine();
                                Console.WriteLine("Create a account with a balance");
                                double zerobal = Convert.ToDouble(Console.ReadLine());
                                string zerotype = "Zero Balance";
                                accounts = new Accounts() { AccountId = zeroId, CustomerName = zeroName, Balance = zerobal, AccountType = zerotype };
                                zero.CreateAccount(accounts);

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
                        savings.listAll();
                        break;
                    case 3:
                        Console.WriteLine("Calculating the interest ");
                        Console.WriteLine("Enter the Account Id you want to Calculate");
                        int interestId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Account Type");
                        string interestType = Console.ReadLine();
                        if(interestType == "Savings")
                        {
                            savings.calculateInterest(interestId);
                        }
                        else if(interestType == "Current"){
                            current.calculateInterest(interestId);
                        }
                        else
                        {
                            zero.calculateInterest(interestId);
                        }


                        break;

                    default:
                        return;
                }
            }
        }
    }
}
