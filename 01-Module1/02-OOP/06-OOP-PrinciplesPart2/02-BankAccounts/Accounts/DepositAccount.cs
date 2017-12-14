namespace _02_BankAccounts
{
    class DepositAccount : Account
    {
        public DepositAccount(Customer customerType, decimal balance, double interestRate) : base(customerType, balance, interestRate)
        {
        }

        public void WithdrawMoney(decimal withdrawAmount)
        {
            this.Balance -= withdrawAmount;
        }

        protected override int AdditionalCalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return months;
        }
    }
}
