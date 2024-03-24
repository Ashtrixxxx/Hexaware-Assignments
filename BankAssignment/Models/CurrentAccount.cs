using BankAssignment.Exceptions;
using BankAssignment.Utilities;
using Microsoft.Data.SqlClient;
using OopsTask7.Repository;
using System;
using System.Collections.Generic;

namespace OopsTask7.Models
{
    internal class CurrentAccount : BankAccount
    {
        public double InterestRate { get; set; } = 4.5;
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public CurrentAccount()
        {
            sql = new SqlConnection(DbUtil.GetConnection());
            cmd = new SqlCommand();
        }

        public double OverDraftLimit { get; set; } = 10000;

        public override void CreateAccount(Accounts bankAccount)
        {
            bankAccounts.Add(bankAccount);
            Console.WriteLine($"Your Account has been created naming {bankAccount.CustomerName} and the AccountId is  {bankAccount.AccountId}");
        }
        public override void listAll()
        {
            foreach (Accounts acc in bankAccounts)
            {
                Console.WriteLine(acc);
            }
        }
        public override void deposit(int id, double amount)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
            currentAccount.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {currentAccount.Balance}");
        }

        public override void calculateInterest(int id)
        {
            Console.WriteLine("Current account has no interest");
        }

        public override void withdraw(int id, double amount)
        {
            try
            {
                cmd.CommandText = "SELECT balance FROM Accounts WHERE account_id = @id";
                cmd.Connection = sql;
                double availableBalance = 0;

                sql.Open();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    availableBalance = (double)((decimal)r["balance"]);
                }
                r.Close(); // Close the SqlDataReader

                if (amount > availableBalance + OverDraftLimit)
                {
                    throw new NoSufficientFundsAvailable("You don't have enough balance");
                }
                else
                {
                    // Update the balance by subtracting the withdrawal amount
                    cmd.CommandText = "UPDATE Accounts SET balance = balance - @amount WHERE account_id = @id";
                    cmd.Parameters.Clear(); // Clear previous parameters

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Console.WriteLine($"Withdrawal successful from account {id}");
                    }
                    else
                    {
                        throw new ServerIssueException("Failed to update balance. There seems to be an issue with the server.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                sql.Close();
            }
        }

        public override void getAccountDetails(int id)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
            Console.WriteLine(currentAccount);
        }

        public override void GetAccountBalance(int id)
        {
            Accounts currentAccount = bankAccounts.Find(x => x.AccountId == id);
            Console.WriteLine($"The bank balance for the account {currentAccount.AccountId} is {currentAccount.Balance}");
        }

        public override void TransferAmount(int sender, int receiver, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
