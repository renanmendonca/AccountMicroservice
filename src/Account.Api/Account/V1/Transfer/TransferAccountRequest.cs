
using Account.Application.UseCases.Transfer;
using System;

namespace Account.Api.Account.V1.Transfer
{
    public class TransferAccountRequest
    {
        public AccountRequest Source { get; set; }

        public AccountRequest Destination { get; set; }
        
        public decimal Amount { get; set; }

        public static implicit operator TransferAccountCommand(TransferAccountRequest request) =>
            new TransferAccountCommand(
                new Application.Common.Account(
                    request.Source.BankId,
                    request.Source.Number,
                    request.Source.Agency,
                    request.Source.Amount
                    ),
                new Application.Common.Account(
                    request.Destination.BankId,
                    request.Destination.Number,
                    request.Destination.Agency,
                    request.Destination.Amount
                    ),
                request.Amount
                );
    }
}
