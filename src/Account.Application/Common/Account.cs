namespace Account.Application.Common
{
    public class Account
    {
        public Account(
            int bankId,
            string number,
            string agency,
            decimal amount)
        {
            Number = number;
            BankId = bankId;
            Agency = agency;
            Amount = amount;
        }

        public int BankId { get; private set; }

        public string Number { get; private set; }

        public string Agency { get; private set; }

        public decimal Amount { get; private set; }
    }
}
