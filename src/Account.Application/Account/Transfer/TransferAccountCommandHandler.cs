using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Common;
using Account.Application.Services;
using Account.Application.UseCases.Account.Credit;
using Account.Application.UseCases.Account.Debit;
using Account.Domain.Commands;
using MediatR;

namespace Account.Application.UseCases.Transfer
{
    public class TransferAccountCommandHandler : ICommandHandler<TransferAccountCommand, Response<Guid>>
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;

        public TransferAccountCommandHandler(
            IMediator mediator,
            IEmailService emailService)
        {
            _mediator = mediator;
            _emailService = emailService;
        }
        public async Task<Response<Guid>> Handle(TransferAccountCommand request, CancellationToken cancellationToken)
        {
            if (request.Invalid)
            {
                return new Response<Guid>(request.Notifications.Select(p => p.Message));
            }

            var source = new Domain.Entities.Account(
                request.Source.BankId,
                request.Source.Number,
                request.Source.Agency,
                request.Source.Amount
                );

            var destination = new Domain.Entities.Account(
                request.Destination.BankId,
                request.Destination.Number,
                request.Destination.Agency,
                request.Destination.Amount
                );
            
            var debitResponse = await _mediator.Send(new DebitAccountCommand(source.BankId, source.Number, source.Agency, source.Amount));
            var creditResponse = await _mediator.Send(new CreditAccountCommand(destination.BankId, destination.Number, destination.Agency, destination.Amount));

            await _emailService.SendEmail(
                new EmailDto { 
                    From = "atendimento@online.com",
                    To = "user@bank.com",
                    Subject = "Tranferência realizada com sucesso",
                    Body = $"Uma nova transferência foi realizada no valor de: {request.Amount}"
                });

            return new Response<Guid>(Guid.NewGuid());
        }    
    }
}
