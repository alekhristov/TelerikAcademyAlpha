namespace _02_BankAccounts
{
    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customerType, decimal balance, double interestRate) : base(customerType, balance, interestRate)
        {
        }

        protected override int AdditionalCalculateInterest(int months)
        {
            if (this.CustomerType == Customer.Individual)
            {
                if (months > 6)
                {
                    return months - 6;
                }
                return 0;
            }
            else if (this.CustomerType == Customer.Company)
            {
                if (months > 12)
                {
                    return months - 6;
                }
                months /= 2;
            }
            return months;
        }
    }
}
