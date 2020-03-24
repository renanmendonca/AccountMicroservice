namespace Account.Api.Account.V1.Transfer
{
    public class AccountRequest
    {        
        public int BankId { get; set; }

        public string Number { get; set; }

        public string Agency { get; set; }

        public decimal Amount { get; set; }
    }
}
