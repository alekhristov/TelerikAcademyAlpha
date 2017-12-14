using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankAccounts
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICollection<IAccount> accounts = new List<IAccount>()
            {
                new DepositAccount(Customer.Company, 200, 5.5),
                new DepositAccount(Customer.Individual, 1000, 6),
                new LoanAccount(Customer.Company, 300, 4),
                new MortgageAccount(Customer.Individual, 6000, 10)
            };

            foreach (var account in accounts)
            {
                Console.WriteLine($"Current Balance: {account.Balance}");
                Console.WriteLine($"Interest amount: {account.CalculateInterestAmount(6)}");
            }
        }
    }
}
