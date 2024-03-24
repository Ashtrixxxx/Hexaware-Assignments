using BankAssignment.Exceptions;
using BankAssignment.Utilities;
using Microsoft.Data.SqlClient;
using OopsTask7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment.Repository
{
    internal class ICustomerProviderImp : ICustomerProvider
    {
        SqlConnection sql = null;
        SqlCommand cmd = null;
        SavingsAccount savings = new SavingsAccount();
        CurrentAccount current = new CurrentAccount();
        ZeroBalance zero = new ZeroBalance();
        public ICustomerProviderImp() {
            sql = new SqlConnection(DbUtil.GetConnection());
            cmd = new SqlCommand();

        }

        public override void getAccountDetails(int id)
        {

            try
            {
                cmd.CommandText = "Select * from Accounts where account_id = @id";
                cmd.Connection = sql;

                sql.Open();
                cmd.Parameters.AddWithValue("@id", id);

                int accountid1 = 0;
                int customerId = 0;
                string type = "";
                double Balance = 0;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        accountid1 = (int)r["account_id"];
                        customerId = (int)r["customer_id"];
                        type = (string)r["account_type"];
                        Balance = (double)((decimal)r["balance"]);
                    }
                }

                Console.WriteLine($"Account Id : {accountid1} \t Customer Id : {customerId} \t Account Type : {type} \t Account Balance : {Balance}");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            
            finally
            {
                    sql.Close(); 
            }

        }

        public override void deposit(int id, double amount)
        {
            try
            {
                cmd.CommandText = "update Accounts set balance=balance + @amount where account_id = @id";

                cmd.Connection = sql;

                sql.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@amount", amount);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine($"Thank you for using the Bank {id}");
                }
                else
                {
                    throw new ServerIssueException("There seems to be a issue with the server");
                }
            }
            catch (SqlException sqlexp)
            {
                Console.WriteLine(sqlexp.Message);
            }
            sql.Close();
        }


        public override void withdraw(int id, double amount)
        {
            try
            {
                cmd.CommandText = "select account_type from Accounts where account_id = @id";
                cmd.Connection = sql;
                sql.Open();
                string type = "";
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    type = (string)r["account_type"];
                }

                if (type == "Savings")
                {
                    savings.withdraw(id, amount);
                }
                else if (type == "Current")
                {
                    current.withdraw(id, amount);

                }
                else
                {
                    zero.withdraw(id, amount);
                }
            }
            catch(SqlException sqlexp)
            {
                Console.WriteLine(sqlexp.Message);
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
                cmd.CommandText = "SELECT * FROM Accounts WHERE account_id = @sender OR account_id = @receiver";
                cmd.Connection = sql;
                cmd.Parameters.AddWithValue("@sender", sender);
                cmd.Parameters.AddWithValue("@receiver", receiver);

                sql.Open();

                Dictionary<int, double> accountBalances = new Dictionary<int, double>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int accountId = (int)reader["account_id"];
                        double balance = (double)((decimal)reader["balance"]); ;
                        accountBalances.Add(accountId, balance);
                    }
                }

                if (!accountBalances.ContainsKey(sender))
                {
                    throw new Exception("The sender account does not exist.");
                }

                if (!accountBalances.ContainsKey(receiver))
                {
                    throw new Exception("The receiver account does not exist.");
                }

                if (accountBalances[sender] < amount)
                {
                    throw new Exception("The sender does not have sufficient balance to transfer.");
                }

                cmd.CommandText = "UPDATE Accounts SET balance = @senderBalance WHERE account_id = @sender;" +
                                  "UPDATE Accounts SET balance = @receiverBalance WHERE account_id = @receiver;";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@sender", sender);
                cmd.Parameters.AddWithValue("@receiver", receiver);
                cmd.Parameters.AddWithValue("@senderBalance", accountBalances[sender] - amount);
                cmd.Parameters.AddWithValue("@receiverBalance", accountBalances[receiver] + amount);
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine($"Transfer of {amount} from account {sender} to account {receiver} successful.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                sql.Close();
            }
        }


        public override void GetAccountBalance(int id)
        {
            try
            {
                cmd.CommandText = "Select balance from Accounts where account_id = @id";
                cmd.Connection = sql;

                sql.Open();
                cmd.Parameters.AddWithValue("@id", id);

              
                double Balance = 0;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        
                        Balance = (double)((decimal)r["balance"]);
                    }
                }

                Console.WriteLine($"Your Account Balance is : {Balance}");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            
            finally
            {
                    sql.Close(); 
            }
        }

        }
    }
