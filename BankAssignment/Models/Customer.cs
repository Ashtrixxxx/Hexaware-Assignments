using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsTask7.Models
{
    internal class Customer
    {

        string customer_id;
        string first_name;
        string last_name;
        string email;
        string phone;
        string addrs;

        // default connstructor 

        public Customer()
        {
            CustomerId = "";
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Addrs = "";

        }

        public Customer(string customerId,string frst,string last, string email, string phone, string addrs)
        {
            CustomerId= customerId; 
            FirstName = frst;
            LastName = last;
            Email = email;
            Phone = phone;
            Addrs = addrs;
        }

        public string CustomerId
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Addrs
        {
            get { return addrs; }
            set { addrs = value; }
        }

        //printing functions

        public void printDetails()
        {
            Console.WriteLine($"The customer Id is :{CustomerId}");
            Console.WriteLine($"The Customer frst name is :{FirstName}");
            Console.WriteLine($"The Customer Last Name is :{LastName}");
            Console.WriteLine($"The cusomer email id{Email}");
            Console.WriteLine($"The customer Phone number is {Phone}");
            Console.WriteLine($"The Address of the customer is {Addrs}");
        }

    }
}
