using System.Collections.Generic;

namespace _02_BankAccounts
{
    public interface ICustomer
    {
        ICollection<IAccount> BankAccounts { get; }
    }
}