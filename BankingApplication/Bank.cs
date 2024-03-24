using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7
{
    internal class Bank
    {

        public static void Main(string[] args)
        {
            BankServiceProvider bankProvider = new BankServiceProvider();
            CustomerServiceProvider customerProvider = new CustomerServiceProvider();

            while(true)
            {
                Console.WriteLine("Welcome To Banking System");
                Console.WriteLine("-----------------------");

                Console.WriteLine("1. Customer Services");
                Console.WriteLine("2. Bank Services");
                Console.WriteLine("Choose a option ");
                int id = Convert.ToInt32(Console.ReadLine());
                switch(id)
                {
                    case 1:
                        bankProvider.BankService();
                        break;
                    case 2:
                        customerProvider.CustomerService();
                        break;
                }

            }
        }
    }
}
