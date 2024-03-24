using BankAssignment.Exceptions;
using BankAssignment.Utilities;
using Microsoft.Data.SqlClient;
using OopsTask7.Repository;
using System;


namespace OopsTask7.Models
{
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; } = 4.5;
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public SavingsAccount() {
            sql = new SqlConnection(DbUtil.GetConnection());
            cmd = new SqlCommand();
        }

        public override void CreateAccount(Accounts bankAccount)
        {
                bankAccounts.Add(bankAccount);
            Console.WriteLine($"Your Account has been created naming {bankAccount.CustomerName} and the AccountId is  {bankAccount.AccountId}");

        }

        public override void listAll()
        {
            foreach(Accounts acc in bankAccounts)
            {
                Console.WriteLine(acc);
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

        public override void deposit(int id , double amount)
        {
            Accounts savingsObject = bankAccounts.Find(x=> x.AccountId == id);


            savingsObject.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {savingsObject.Balance}");
        }

        public override void calculateInterest(int id)
        {


            cmd.CommandText = "select balance from Accounts where account_id = @accId";
            cmd.Connection = sql;
            sql.Open();

            cmd.Parameters.AddWithValue("@accId", id);

            SqlDataReader r = cmd.ExecuteReader();
            double Balance = 0;

            while (r.Read())
            {
                Balance = (double)((decimal)r["balance"]);
            }

            //Accounts savingsObject = bankAccounts.Find(x => x.AccountId == id);
            double InterestRate = 4.5;
            double interest = Balance * (InterestRate / 100);
            Console.WriteLine($"Interest calculated: {interest}. New balance: {Balance}");
        }
                                                            
        public override void withdraw(int id,double amount)
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

                if (amount > availableBalance)
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

        public override void TransferAmount(int sender, int receiver, double amount)
        {
            try
            {


                Accounts senderAccount = bankAccounts.Find(x => x.AccountId == sender);
                Accounts recieverAccount = bankAccounts.Find(x => x.AccountId == receiver);

                if (senderAccount == null)
                {
                    throw new Exception("The sender Id does not exist");
                }

                else if(recieverAccount == null)
                {
                    throw new Exception("The Account you are trying to send doesnot exist");
                }
                else
                {
                    senderAccount.Balance -= amount;
                    recieverAccount.Balance += amount;
                    Console.WriteLine($"The new balance of sender is {senderAccount.Balance} and reciever Account is {recieverAccount.Balance}");
                }
            }catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
