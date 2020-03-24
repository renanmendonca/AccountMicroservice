using Account.Application.Common;
using Account.Domain.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Account.Application.UseCases.Transfer
{
    public class TransferAccountCommand : Notifiable, ICommand<Response<Guid>>
    {
        public TransferAccountCommand(
            Common.Account source,
            Common.Account destination,
            decimal amount)
        {
            Source = source;
            Destination = destination;
            Amount = amount;
        }

        public Common.Account Source { get; }

        public Common.Account Destination { get; }

        public decimal Amount { get; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNull(Amount, nameof(Amount), "Amount cannot be null")
            );
        }
    }
}
