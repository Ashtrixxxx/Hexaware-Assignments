using OopsTask7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment.Repository
{
    internal abstract class IBankProvider : Accounts
    {
        public abstract List<Accounts> listAll();

        public abstract void CreateAccount(Accounts account);

        public abstract void CalculateInterest(int id);
    }
}
