namespace _02_BankAccounts
{
    abstract class Account : IAccount
    {
        public Account(Customer customerType, decimal balance, double interestRate)
        {
            this.CustomerType = customerType;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer CustomerType { get; protected set; }

        public decimal Balance { get; protected set; }

        public double InterestRate { get; protected set; }

        public virtual void DepositMoney(decimal depositAmount)
        {
            this.Balance += depositAmount;
        }

        public virtual double CalculateInterestAmount(int months)
        {
            months = AdditionalCalculateInterest(months);
            return InterestRate * months;
        }

        protected abstract int AdditionalCalculateInterest(int months);
    }
}
