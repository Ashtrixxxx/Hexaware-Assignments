using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Models
{
    public class Accounts
    {

        public static  List<Accounts> bankAccounts  = new List<Accounts>();   

        public Accounts()
        {
        }

        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public string CustomerName { get; set; }

        public int CustomerId { get; set; }

        //Methods 

        public override string ToString()
        {
            return $"{AccountId} \t {AccountType} {CustomerId} \t {Balance}";
        }



     



    }
}
