using Account.Application.Common;
using Account.Domain.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Account.Application.UseCases.Account.Debit
{
    public class DebitAccountCommand : Notifiable, ICommand<Response<Guid>>
    {
        public DebitAccountCommand(
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

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNull(BankId, nameof(BankId), "Debit Account Bank cannot be null")
                .IsNull(Number, nameof(Number), "Debit Account Number cannot be null")
                .IsNull(Agency, nameof(Agency), "Debit Account Agency cannot be null")
                .IsLowerOrEqualsThan(Amount, 0, nameof(Amount), "Invalid debit value")
            );
        }
    }
}
