using Flunt.Validations;
using System;

namespace Account.Domain.Entities
{
    public class Account : Entity<Account, Guid>
    {
        public Account()
        {
                
        }

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

        public void Credit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid credit value");
            }

            Amount = +amount;
        }

        public void Debit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid debit value");
            }

            if (Amount < amount)
            {
                throw new Exception("Insufficient funds");
            }

            Amount = -amount;
        }

        public override void ValidateProperties()
        {
            AddNotifications(new Contract()
                .IsNull(BankId, nameof(BankId), "Account Bank cannot be null")
                .IsNull(Number, nameof(Number), "Account Number cannot be null")
                .IsNull(Agency, nameof(Agency), "Account Agency cannot be null")
            );
        }
    }
}
