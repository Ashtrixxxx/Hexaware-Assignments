using BankAssignment.Utilities;
using OopsTask7.Models;
using OopsTask7.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using OopsTask7.Exceptions;

namespace BankAssignment.Repository
{

    internal class IBankProviderImp : IBankProvider
    {

        SavingsAccount savings = new SavingsAccount();
        ZeroBalance zero = new ZeroBalance();
        CurrentAccount current = new CurrentAccount();
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public IBankProviderImp()
        {
            cmd = new SqlCommand();
            sql = new SqlConnection(DbUtil.GetConnection());
        }

        public override void CalculateInterest( string id)
        {

            try
            {
                int dId = 0;
                InvalidInputException.CheckIfInteger(id, ref dId);

                


                try
                {
                    cmd.CommandText = "select account_type from Accounts where account_id = @id";
                    cmd.Connection = sql;
                    sql.Open();
                    string type = "";
                    cmd.Parameters.AddWithValue("@id", dId);

                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        type = (string)r["account_type"];
                    }

                    if (type == "Savings")
                    {
                        savings.calculateInterest(dId);
                    }
                    else if (type == "Current")
                    {
                        current.calculateInterest(dId);

                    }
                    else
                    {
                        zero.calculateInterest(dId);
                    }
                }
                catch (SqlException sqlexp)
                {
                    Console.WriteLine(sqlexp.Message);
                }
                finally
                {
                    sql.Close();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public override List<Accounts> listAll()
        {
            List<Accounts> ac = new List<Accounts>();
            
            cmd.CommandText= "Select * from Accounts";
            cmd.Connection = sql;

            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Accounts a = new Accounts();

                a.AccountId = (int)reader["account_id"];
                a.CustomerId = (int)reader["customer_id"];
                a.AccountType = (string)reader["account_type"];
                a.Balance =(double)((decimal)reader["balance"]);
                //Console.WriteLine(a.AccountId);
                ac.Add(a);

            }
            sql.Close();


            return ac;
        }

        public override void CreateAccount(Accounts bankAccount)
        {
            cmd.CommandText = "insert into Accounts(customer_id,account_type,balance) values(@customerId,@accounttype,@balance)";
            cmd.Connection = sql;
            sql.Open();
            //cmd.Parameters.AddWithValue("@id",bankAccount.AccountId);
            cmd.Parameters.AddWithValue("@customerId", bankAccount.CustomerId);
            cmd.Parameters.AddWithValue("@accounttype", bankAccount.AccountType);
            cmd.Parameters.AddWithValue("@balance", bankAccount.Balance);
            int rows = cmd.ExecuteNonQuery();
            cmd.CommandText = "Select account_id from Accounts where customer_id = @id and account_type = @type and balance = @b";
            cmd.Parameters.AddWithValue("@id", bankAccount.CustomerId);
            cmd.Parameters.AddWithValue("@type", bankAccount.AccountType);
            cmd.Parameters.AddWithValue("@b", bankAccount.Balance);
            SqlDataReader r = cmd.ExecuteReader();
            int id = 0;
            while (r.Read())
            {
                 id = (int)r["account_id"];
            }
            //bankAccounts.Add(bankAccount);
            Console.WriteLine($"Your Account has been created naming {bankAccount.CustomerName} and the AccountId is {id}");
        }

    }
}
