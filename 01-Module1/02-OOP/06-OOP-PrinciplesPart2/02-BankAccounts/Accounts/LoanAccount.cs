namespace _02_BankAccounts
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customerType, decimal balance, double interestRate) : base(customerType, balance, interestRate)
        {
        }

        protected override int AdditionalCalculateInterest(int months)
        {
            if (this.CustomerType == Customer.Individual)
            {
                if (months <= 3)
                {
                    return 0;
                }
                months -= 3;
            }
            else if (this.CustomerType == Customer.Company)
            {
                if (months <= 2)
                {
                    return 0;
                }
                months -= 2;
            }
            return months;
        }
    }
}
