using BankAssignment.Utilities;
using OopsTask7.Models;
using Microsoft.Data.SqlClient;

namespace BankAssignment.Repository
{

    internal class IBankProviderImp : IBankProvider
    {
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public IBankProviderImp()
        {
            cmd = new SqlCommand();
            sql = new SqlConnection(DbUtil.GetConnection());
        }

        public override void CalculateInterest( int id)
        {
            Accounts savingsObject = bankAccounts.Find(x => x.AccountId == id);
            double InterestRate = 4.5;
            double interest = savingsObject.Balance * (InterestRate / 100);
            Console.WriteLine($"Interest calculated: {interest}. New balance: {savingsObject.Balance}");
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
            //bankAccounts.Add(bankAccount);
            Console.WriteLine($"Your Account has been created naming {bankAccount.CustomerName} and the AccountId is  {bankAccount.AccountId}");
        }

    }
}
