﻿//using OopsTask7.Exceptions;
//using OopsTask7.Models;
//using OopsTask7.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace OopsTask7
//{
//    internal class BankingApp
//    {
//        public static void CustomerServiceProvider(string[] args)
//        {
//            int randomNumber = 1000;
//            SavingsAccount savings = new SavingsAccount();
//            ZeroBalance zero = new ZeroBalance();
//            CurrentAccount current = new CurrentAccount();
//        Mainmenu: while (true)
//            {
//                Console.WriteLine("Welcome to the Banking App");
//                Console.WriteLine("1. Get Account Balance");
//                Console.WriteLine("2. Deposit Money to the account");
//                Console.WriteLine("3. Withdraw Money");
//                Console.WriteLine("4. Transfer Money to other Account");
//                Console.WriteLine("5. Get my Account details");

//                Console.WriteLine("Enter Your choice");
//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:

//                        Console.WriteLine("Select the type of Account ");
//                        Console.WriteLine("1. Savings Account");
//                        Console.WriteLine("2. Current Account");
//                        Console.WriteLine("3. Zero Balance Account");
//                        int ch = Convert.ToInt32(Console.ReadLine());
//                        switch (ch)
//                        {
//                            case 1:
//                                Accounts accounts = new Accounts();
//                                int accId = randomNumber++;
//                                Console.WriteLine("Create your Account Name:");
//                                string accName = Console.ReadLine();
//                                Console.WriteLine("Create a account with a balance");
//                                double bal = Convert.ToDouble(Console.ReadLine());
//                                string type = "Savings";
//                                accounts = new Accounts() { AccountId = accId, CustomerName = accName, Balance = bal, AccountType = type };
//                                savings.CreateAccount(accounts);
//                                //Console.WriteLine(savings.CustomerName);
//                                break;
//                            case 2:
//                                int currentacc = randomNumber++;
//                                Console.WriteLine("Create your Account Name:");
//                                string curraccName = Console.ReadLine();
//                                Console.WriteLine("Create a account with a balance");
//                                double currbal = Convert.ToDouble(Console.ReadLine());
//                                string currtype = "Current";
//                                accounts = new Accounts() { AccountId = currentacc, CustomerName = curraccName, Balance = currbal, AccountType = currtype };
//                                current.CreateAccount(accounts);
//                                break;
//                            case 3:
//                                int zeroId = randomNumber++;
//                                Console.WriteLine("Create your Account Name:");
//                                string zeroName = Console.ReadLine();
//                                Console.WriteLine("Create a account with a balance");
//                                double zerobal = Convert.ToDouble(Console.ReadLine());
//                                string zerotype = "Zero Balance";
//                                accounts = new Accounts() { AccountId = zeroId, CustomerName = zeroName, Balance = zerobal, AccountType = zerotype };
//                                zero.CreateAccount(accounts);

//                                break;
//                            default:
//                                Console.WriteLine("Invalid option");
//                                break;
//                        }
//                        break;

//                    case 2:
//                        Console.WriteLine("Deposit Money to your Account");
//                        Console.WriteLine("Enter your Account Id ");
//                        string depositId = Console.ReadLine();
//                        Console.WriteLine("Enter your Account Type");
//                        string depositType = Console.ReadLine();
//                        Console.WriteLine("Enter your amount ");
//                        double money = Convert.ToDouble(Console.ReadLine());
//                        if (!int.TryParse(depositId, out int outId))
//                        {
//                            throw new InvalidInputException("Please check your AccountId again");
//                        }

//                        if (depositType == "Savings")
//                        {
//                            savings.deposit(outId, money);
//                        }
//                        else if (depositType == "Current")
//                        {
//                            current.deposit(outId, money);
//                        }
//                        else
//                        {
//                            zero.deposit(outId, money);
//                        }

//                        break;

//                    case 3:
//                        Console.WriteLine("Withdraw Money from your Account");
//                        Console.WriteLine("Enter your Account Id ");
//                        string withdrawId = Console.ReadLine();
//                        Console.WriteLine("Enter your Account Type");
//                        string withdrawType = Console.ReadLine();
//                        Console.WriteLine("Enter your amount ");
//                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
//                        if (!int.TryParse(withdrawId, out int outWithdrawId))
//                        {
//                            throw new InvalidInputException("Please check your AccountId again");
//                        }

//                        if (withdrawType == "Savings")
//                        {
//                            savings.withdraw(outWithdrawId, withdrawAmount);
//                        }
//                        else if (withdrawType == "Current")
//                        {
//                            current.withdraw(outWithdrawId, withdrawAmount);
//                        }
//                        else
//                        {
//                            zero.withdraw(outWithdrawId, withdrawAmount);
//                        }

//                        break;

//                    case 4:
//                        Console.WriteLine("Transfer Your amount to your Friends and family");
//                        Console.WriteLine("Enter Your Account id");
//                        int sender = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter The account id you want to send the money to :");
//                        int receiver = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter the Amount you want to Transfer");
//                        double transferAmount = Convert.ToDouble(Console.ReadLine());
//                        Console.WriteLine("Enter Your Account Type:");
//                        string transferType = Console.ReadLine();

//                        if (transferType == "Savings")
//                        {
//                            savings.TransferAmount(sender, receiver, transferAmount);
//                        }
//                        else if (transferType == "Current")
//                        {
//                            current.TransferAmount(sender, receiver, transferAmount);
//                        }
//                        else
//                        {
//                            zero.TransferAmount(sender, receiver, transferAmount);
//                        }





//                        break;
//                    case 5:
//                        Console.WriteLine("Enter your Account Id");
//                        string getAccId = Console.ReadLine();
//                        Console.WriteLine(" Enter Your Account Type");
//                        string getAccType = Console.ReadLine();
//                        if (!int.TryParse(getAccId, out int outAccId))
//                            throw new InvalidInputException("Please recheck your Account Id");

//                        if (getAccType == "Savings")
//                            savings.getAccountDetails(outAccId);
//                        else if (getAccType == "Current")
//                            current.getAccountDetails(outAccId);
//                        else
//                        {
//                            zero.getAccountDetails(outAccId);
//                        }
//                        break;
//                }

//            }

//        }

//    }
//}
