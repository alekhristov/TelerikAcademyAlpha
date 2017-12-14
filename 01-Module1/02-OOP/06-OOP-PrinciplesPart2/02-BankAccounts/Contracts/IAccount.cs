namespace _02_BankAccounts
{
    public interface IAccount
    {
        Customer CustomerType { get; }

        decimal Balance { get; }

        double InterestRate { get; }

        void DepositMoney(decimal amount);

        double CalculateInterestAmount(int months);
    }
}
