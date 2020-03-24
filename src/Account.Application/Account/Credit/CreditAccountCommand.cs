using Account.Application.Common;
using Account.Domain.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Account.Application.UseCases.Account.Credit
{
    class CreditAccountCommand : Notifiable, ICommand<Response<Guid>>
    {
        public CreditAccountCommand(
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
                .IsNull(BankId, nameof(BankId), "Credit Account Bank cannot be null")
                .IsNull(Number, nameof(Number), "Credit Account Number cannot be null")
                .IsNull(Agency, nameof(Agency), "Credit Account Agency cannot be null")                
            );
        }
    }
}
