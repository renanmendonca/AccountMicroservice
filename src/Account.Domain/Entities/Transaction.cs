using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Entities
{
    public class Transaction : Entity<Account, Guid>
    {
        public Transaction()
        {

        }

        public Transaction(
            Guid accountId, 
            decimal amount, 
            Enums.OperationType operationType)
        {
            AccountId = accountId;
            Amount = amount;
            OperationType = operationType;
        }

        public Guid AccountId { get; private set; }

        public decimal Amount { get; private set; }

        public Enums.OperationType OperationType { get; private set; }

        public override void ValidateProperties()
        {
            AddNotifications(new Contract()
                .IsNull(AccountId, nameof(AccountId), "Transaction Account cannot be null")
                .IsLowerOrEqualsThan(Amount, 0, nameof(Amount), "Transaction Amount must be greater than 0")
                .IsNull(OperationType, nameof(OperationType), "Transaction OperationType cannot be null")
            );
        }
    }
}
