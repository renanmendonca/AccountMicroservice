using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Common;
using Account.Domain.Commands;
using Account.Domain.Entities;
using Account.Domain.Interfaces.Repositories;

namespace Account.Application.UseCases.Account.Debit
{
    class DebitAccountCommandHandler : ICommandHandler<DebitAccountCommand, Response<Guid>>
    {
        private readonly IAccountReadRepository _accountReadRepository;
        private readonly IAccountWriteRepository _accountWriteRepository;
        private readonly ITransactionWriteRepository _transactionWriteRepository;

        public DebitAccountCommandHandler(
            IAccountReadRepository accountReadRepository,
            IAccountWriteRepository accountWriteRepository,
            ITransactionWriteRepository transactionWriteRepository)
        {
            _accountReadRepository = accountReadRepository;
            _accountWriteRepository = accountWriteRepository;
            _transactionWriteRepository = transactionWriteRepository;
        }

        public async Task<Response<Guid>> Handle(DebitAccountCommand request, CancellationToken cancellationToken)
        {
            if (request.Invalid)
            {
                return new Response<Guid>(request.Notifications.Select(p => p.Message));
            }

            // Get Account from Database
            var account = await _accountReadRepository.GetAccountAsync(request.BankId, request.Number, request.Agency);

            account.Debit(request.Amount);

            // Create Account Transaction
            var transactionId = await _transactionWriteRepository.CreateAsync(
                new Transaction(account.Id, request.Amount, Domain.Enums.OperationType.Debit)
                );

            // Update Account overbalance
            await _accountWriteRepository.UpdateAsync(account);

            return new Response<Guid>(transactionId);
        }
    }
}
