using System.Data;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string password = "ashwin23@hi";
            Console.WriteLine("Enter your password to validate");
            string password = Console.ReadLine();
            if (password.Length > 8 && password.Any(Char.IsUpper) && password.Any(Char.IsLower) && containsSpecial(password) )
            {
                Console.WriteLine("Yes the password is valid");
            }
            else
            {
                Console.WriteLine("No the Given password is not valid");
            }
        }


        static bool containsSpecial(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
